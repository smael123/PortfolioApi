using System;
using System.Collections.ObjectModel;

namespace PortfolioApi.Models
{
    public class SkillGroup : IOwnedItem
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Skill> Skills { get; set; } = new Collection<Skill>();
        public int Order { get; set; }
        public string? OwnerId { get; set; }
    }
}

