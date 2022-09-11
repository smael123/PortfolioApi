using System;
using System.Text.Json.Serialization;

namespace PortfolioApi.DTOs
{
    public class Project
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? CompanyName { get; set; }
        [JsonPropertyName("tech")]
        public IEnumerable<ProjectTech> ProjectTeches { get; set; } = Enumerable.Empty<ProjectTech>();
        public IEnumerable<BasicHyperLink> ProjectLinks { get; set; } = Enumerable.Empty<BasicHyperLink>();
        public IEnumerable<BasicImageLink> ImageLinks { get; set; } = Enumerable.Empty<BasicImageLink>();
    }
}

