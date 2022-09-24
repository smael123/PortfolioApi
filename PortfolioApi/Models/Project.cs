using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace PortfolioApi.Models
{
    public class Project : IOwnedItem
    {
        public string? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? CompanyName { get; set; }
        public string? ProjectType { get; set; }
        [JsonProperty("tech")]
        public ICollection<ProjectTech> ProjectTeches { get; set; } = new Collection<ProjectTech>();
        public ICollection<BasicHyperLink> ProjectLinks { get; set; } = new Collection<BasicHyperLink>();
        public ICollection<BasicImageLink> ImageLinks { get; set; } = new Collection<BasicImageLink>();
        public string? OwnerId { get; set; }
    }
}

