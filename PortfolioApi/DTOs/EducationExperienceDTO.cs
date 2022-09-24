using System;
using System.Text.Json.Serialization;

namespace PortfolioApi.DTOs
{
    public class EducationExperienceDTO
    {
        public string? Id { get; set; }
        public string? SchoolName { get; set; }
        public string? Degree { get; set; }
        public int YearOfGraduation { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        [JsonPropertyName("courses")]
        public IEnumerable<EducationCourseDTO> EducationCourses { get; set; } = Enumerable.Empty<EducationCourseDTO>();
        public string? OwnerId { get; set ; }
    }
}

