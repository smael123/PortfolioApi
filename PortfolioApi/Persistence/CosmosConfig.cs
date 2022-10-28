using System;

namespace PortfolioApi.Persistence
{
    public class CosmosConfig
    {
        public string AccountEndpoint { get; init; }
        public string AuthKeyOrResourceToken { get; init; }
        public string DatabaseId { get; init; }

        public CosmosConfig(string? accountEndpoint, string? authKeyOrResourceToken, string? databaseId)
        {
            const string errorMessage = "{0} is null or empty.";

            if (string.IsNullOrWhiteSpace(accountEndpoint))
            {
                throw new ArgumentException(string.Format(errorMessage, nameof(accountEndpoint)));
            }

            if (string.IsNullOrWhiteSpace(authKeyOrResourceToken))
            {
                throw new ArgumentException(string.Format(errorMessage, nameof(authKeyOrResourceToken)));
            }

            if (string.IsNullOrWhiteSpace(databaseId))
            {
                throw new ArgumentException(string.Format(errorMessage, nameof(databaseId)));
            }

            AccountEndpoint = accountEndpoint;
            AuthKeyOrResourceToken = authKeyOrResourceToken;
            DatabaseId = databaseId;
        }
    }
}

