using System;
using System.Text.Json;
using Microsoft.Azure.Cosmos;
using PortfolioApi.Models;

namespace PortfolioApi.Persistence.Repositories
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(CosmosConfig cosmosConfig, string containerName) : base(cosmosConfig, containerName) { }

        public async Task<List<Project>> GetProjectsByOwnerAndType(string ownerId, string projectType)
        {
            using CosmosClient client = new(
                accountEndpoint: _cosmosConfig.AccountEndpoint,
                authKeyOrResourceToken: _cosmosConfig.AuthKeyOrResourceToken
            );

            Database database = client.GetDatabase(_cosmosConfig.DatabaseId);
            Container container = database.GetContainer(_containerName);

            const string query = "SELECT * FROM p where p.ownerId = @ownerId and p.projectType = @projectType";

            QueryDefinition queryDefinition = new QueryDefinition(query)
                .WithParameter("@ownerId", ownerId)
                .WithParameter("@projectType", projectType);

            using FeedIterator<Project> feed = container.GetItemQueryIterator<Project>(queryDefinition);

            List<Project> projects = new();

            while (feed.HasMoreResults)
            {
                FeedResponse<Project> feedResponse = await feed.ReadNextAsync();

                projects.AddRange(feedResponse);
            }

            return projects;
        }
    }
}

