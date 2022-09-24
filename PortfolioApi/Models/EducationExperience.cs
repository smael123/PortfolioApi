using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace PortfolioApi.Models
{
    public class EducationExperience : IOwnedItem
    {
        public string? Id { get; set; }
        public string? SchoolName { get; set; }
        public string? Degree { get; set; }
        public int YearOfGraduation { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public ICollection<EducationCourse> EducationCourses { get; set; } = new Collection<EducationCourse>();
        public string? OwnerId { get; set ; }
    }
}

