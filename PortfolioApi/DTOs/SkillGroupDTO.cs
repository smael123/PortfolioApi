using System;

namespace PortfolioApi.DTOs
{
    public class SkillGroupDTO
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public IEnumerable<SkillDTO> Skills { get; set; } = Enumerable.Empty<SkillDTO>();
        public int Order { get; set; }
        public string? OwnerId { get; set; }
    }
}

