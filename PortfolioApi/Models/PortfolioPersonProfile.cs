using System;
using System.Collections.ObjectModel;

namespace PortfolioApi.Models
{
    public class PortfolioPersonProfile : IOwnedItem
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? CareerTitle { get; set; }
        public string? PictureSrc { get; set; }
        public ICollection<BasicHyperLink> ProfileLinks { get; set; } = new Collection<BasicHyperLink>();
        public DateTimeOffset CreatedDateTime { get; set; }
        public string? OwnerId { get; set; }
    }
}

