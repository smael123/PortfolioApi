using System;
namespace PortfolioApi.DTOs
{
    public interface IOwnedItem
    {
        public string? OwnerId { get; set; } //used as partition key
    }
}

