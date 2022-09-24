using System;
using System.Text.Json.Serialization;

namespace PortfolioApi.DTOs
{
    public class ProjectDTO
    {
        public string? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? CompanyName { get; set; }
        public string? ProjectType { get; set; }
        [JsonPropertyName("tech")]
        public IEnumerable<ProjectTechDTO> ProjectTeches { get; set; } = Enumerable.Empty<ProjectTechDTO>();
        public IEnumerable<BasicHyperLinkDTO> ProjectLinks { get; set; } = Enumerable.Empty<BasicHyperLinkDTO>();
        public IEnumerable<BasicImageLinkDTO> ImageLinks { get; set; } = Enumerable.Empty<BasicImageLinkDTO>();
        public string? OwnerId { get; set; }
    }
}

