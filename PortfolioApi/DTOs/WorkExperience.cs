using System;
using System.Text.Json.Serialization;
using PortfolioApi.JsonConverters;

namespace PortfolioApi.DTOs
{
    public class WorkExperience : IOwnedItem
    {
        public int Id { get; set; }
        public string? CompanyName { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        [JsonPropertyName("startDateStr")]
        public DateOnly StartDate { get; set; }
        [JsonConverter(typeof(NullableDateOnlyJsonConverter))]
        [JsonPropertyName("endDateStr")]
        public DateOnly? EndDate { get; set; }
        public string? Title { get; set; }
        [JsonPropertyName("responsibilities")]
        public IEnumerable<WorkResponsibility> WorkResponsibilities { get; set; } = Enumerable.Empty<WorkResponsibility>();
        public string? OwnerId { get; set; }
    }
}

