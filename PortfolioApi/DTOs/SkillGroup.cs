using System;
namespace PortfolioApi.DTOs
{
    public class SkillGroup
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Skill> Skills { get; set; } = new List<Skill>();
        public int Order { get; set; }
    }
}

