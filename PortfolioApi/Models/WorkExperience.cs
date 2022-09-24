using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace PortfolioApi.Models
{
    public class WorkExperience : IOwnedItem
    {
        public string? Id { get; set; }
        public string? CompanyName { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Title { get; set; }
        [JsonProperty("responsibilities")]
        public ICollection<WorkResponsibility> WorkResponsibilities { get; set; } = new Collection<WorkResponsibility>();
        public string? OwnerId { get; set; }
    }
}

