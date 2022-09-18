using System;
namespace PortfolioApi.Persistence
{
    public class CosmosConfig
    {
        public string AccountEndpoint { get; init; }
        public string AuthKeyOrResourceToken { get; init; }
        public string DatabaseId { get; init; }

        public CosmosConfig(string accountEndpoint, string authKeyOrResourceToken, string databaseId)
        {
            AccountEndpoint = accountEndpoint;
            AuthKeyOrResourceToken = authKeyOrResourceToken;
            DatabaseId = databaseId;
        }
    }
}

