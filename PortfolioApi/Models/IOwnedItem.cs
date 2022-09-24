using System;
namespace PortfolioApi.Models
{
    public interface IOwnedItem
    {
        public string? OwnerId { get; set; } //used as partition key
    }
}

