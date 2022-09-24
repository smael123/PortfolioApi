using System;

namespace PortfolioApi.DTOs
{
    public class PortfolioPersonProfileDTO
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? CareerTitle { get; set; }
        public string? PictureSrc { get; set; }
        public IEnumerable<BasicHyperLinkDTO> ProfileLinks { get; set; } = Enumerable.Empty<BasicHyperLinkDTO>();
        public DateTimeOffset CreatedDateTime { get; set; }
        public string? OwnerId { get; set; }
    }
}

