using System;
using Microsoft.Azure.Cosmos;
using PortfolioApi.DTOs;

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

            string query = $"SELECT * FROM {_containerName} p where p.ownerId = @key and p.projectType = @projectType";

            QueryDefinition queryDefinition = new(query);
            queryDefinition.WithParameter("@ownerId", ownerId);
            queryDefinition.WithParameter("@projectType", projectType);

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

