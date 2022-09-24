using System;
using System.Text.Json;
using Microsoft.Azure.Cosmos;
using PortfolioApi.Models;

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
            const string query = "SELECT * FROM pp where pp.ownerId = @ownerId order by pp.createdDateTime DESC OFFSET 0 LIMIT 1";

            QueryDefinition queryDefinition = new QueryDefinition(query)
                .WithParameter("@ownerId", ownerId);

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

