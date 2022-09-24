using System;
using System.Text.Json;
using Microsoft.Azure.Cosmos;
using PortfolioApi.Models;

namespace PortfolioApi.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : IOwnedItem
    {
        protected readonly CosmosConfig _cosmosConfig;

        protected readonly string _containerName;

        public Repository(CosmosConfig cosmosConfig, string containerName)
        {
            _cosmosConfig = cosmosConfig;

            _containerName = containerName;
        }

        public async Task<List<T>> GetByOwner(string ownerId)
        {
            //CosmosClientOptions options = new()
            //{
            //    Serializer = new CosmosJsonDotNetPortfolioApiSerializer(new CosmosSerializationOptions())
            //};

            using CosmosClient client = new(
                accountEndpoint: _cosmosConfig.AccountEndpoint,
                authKeyOrResourceToken: _cosmosConfig.AuthKeyOrResourceToken//,
               //options
            );

            Database database = client.GetDatabase(_cosmosConfig.DatabaseId);
            Container container = database.GetContainer(_containerName);

            const string query = "SELECT * FROM c where c.ownerId = @ownerId";

            QueryDefinition queryDefinition = new QueryDefinition(query)
                .WithParameter("@ownerId", ownerId);

            using FeedIterator<T> feed = container.GetItemQueryIterator<T>(queryDefinition);

            List<T> items = new();

            while (feed.HasMoreResults)
            {
                FeedResponse<T> feedResponse = await feed.ReadNextAsync();

                items.AddRange(feedResponse);
            }

            return items;
        }
    }
}

