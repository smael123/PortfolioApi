using System;
using Microsoft.Azure.Cosmos;
using PortfolioApi.DTOs;

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
            using CosmosClient client = new(
                accountEndpoint: _cosmosConfig.AccountEndpoint,
                authKeyOrResourceToken: _cosmosConfig.AuthKeyOrResourceToken
            );

            Database database = client.GetDatabase(_cosmosConfig.DatabaseId);
            Container container = database.GetContainer(_containerName);

            string query = $"SELECT * FROM {_containerName} c where c.ownerId = @key";

            QueryDefinition queryDefinition = new(query);
            queryDefinition.WithParameter("@key", ownerId);

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

