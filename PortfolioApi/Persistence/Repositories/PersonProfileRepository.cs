using System;
using Microsoft.Azure.Cosmos;
using PortfolioApi.DTOs;

namespace PortfolioApi.Persistence.Repositories
{
    public class PersonProfileRepository : Repository<PortfolioPersonProfile>, IPersonProfileRepository
    {
        public PersonProfileRepository(CosmosConfig cosmosConfig, string containerName) : base(cosmosConfig, containerName) { }

        public async Task<PortfolioPersonProfile?> GetNewestByOwner(string ownerId)
        {
            using CosmosClient client = new(
                accountEndpoint: _cosmosConfig.AccountEndpoint,
                authKeyOrResourceToken: _cosmosConfig.AuthKeyOrResourceToken
            );

            Database database = client.GetDatabase(_cosmosConfig.DatabaseId);
            Container container = database.GetContainer(_containerName);

            //select newest one
            string query = $"SELECT * FROM {_containerName} pp where pp.ownerId = @key order by ee.createdDateTime DESC LIMIT 1";

            QueryDefinition queryDefinition = new(query);
            queryDefinition.WithParameter("@key", ownerId);

            using FeedIterator<PortfolioPersonProfile> feed = container.GetItemQueryIterator<PortfolioPersonProfile>(queryDefinition);

            PortfolioPersonProfile? personProfile = null;

            if (feed.HasMoreResults)
            {
                FeedResponse<PortfolioPersonProfile> feedResponse = await feed.ReadNextAsync();

                personProfile = feedResponse.FirstOrDefault();
            }

            return personProfile;
        }
    }
}

