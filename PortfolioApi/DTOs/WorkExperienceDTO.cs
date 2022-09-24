using System;
using System.Text.Json.Serialization;
using PortfolioApi.SystemJsonConverters;

namespace PortfolioApi.DTOs
{
    public class WorkExperienceDTO
    {
        public string? Id { get; set; }
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
        public IEnumerable<WorkResponsibilityDTO> WorkResponsibilities { get; set; } = Enumerable.Empty<WorkResponsibilityDTO>();
        public string? OwnerId { get; set; }
    }
}

