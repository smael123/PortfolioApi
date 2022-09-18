using System;
using System.Text.Json.Serialization;

namespace PortfolioApi.DTOs
{
    public class EducationExperience : IOwnedItem
    {
        public int Id { get; set; }
        public string? SchoolName { get; set; }
        public string? Degree { get; set; }
        public int YearOfGraduation { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        [JsonPropertyName("courses")]
        public IEnumerable<EducationCourse> EducationCourses { get; set; } = Enumerable.Empty<EducationCourse>();
        public string? OwnerId { get; set ; }
    }
}

