using System;
namespace PortfolioApi.DTOs
{
    public class EducationExperience
    {
        public int Id { get; set; }
        public string? SchoolName { get; set; }
        public string? Degree { get; set; }
        public int YearOfGraduation { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public List<EducationCourse> EducationCourses { get; set; } = new List<EducationCourse>();
    }
}

