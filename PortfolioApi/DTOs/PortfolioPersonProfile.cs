using System;
namespace PortfolioApi.DTOs
{
    public class PortfolioPersonProfile
    {
        public string? Name { get; set; }
        public string? CareerTitle { get; set; }
        public string? PictureSrc { get; set; }
        public IEnumerable<BasicHyperLink> ProfileLinks { get; set; } = Enumerable.Empty<BasicHyperLink>();
        public DateTimeOffset CreatedDateTime { get; set; }
    }
}

