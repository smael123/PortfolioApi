using System;
namespace PortfolioApi.DTOs
{
    public class SkillGroup
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public IEnumerable<Skill> Skills { get; set; } = Enumerable.Empty<Skill>();
        public int Order { get; set; }
    }
}

