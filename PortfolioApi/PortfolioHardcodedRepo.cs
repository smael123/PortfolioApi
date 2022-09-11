using System;
using PortfolioApi.DTOs;

namespace PortfolioApi
{
    public static class PortfolioHardcodedRepo
    {
        public static List<SkillGroup> GetSkillGroups()
        {
            int skillGroupCounter = 1;
            int skillGroupOrderCounter = 1;

            List<SkillGroup> skillGroups = new()
            {
                new SkillGroup
                {
                    Id = skillGroupCounter++,
                    Name = "Backend",
                    Order = skillGroupOrderCounter++,
                    Skills = new()
                    {
                       new() {
                           Name = "C#",
                           Order = 1
                       },
                       new() {
                            Name = "SQL",
                            Order = 2,
                        },
                        new () {
                            Name = "SQL Server Reporting Services (SSRS)",
                            Order = 3,
                        },
                        new () {
                            Name = "Web API 2",
                            Order = 4,
                        },
                        new() {
                            Name = ".NET MVC",
                            Order = 5,
                        }
                    }
                },
                new SkillGroup
                {
                    Id = skillGroupCounter++,
                    Name = "Frontend",
                    Order = skillGroupOrderCounter++,
                    Skills = new()
                    {
                       new() {
                           Name = "React",
                           Order = 4
                       },
                       new() {
                            Name = "Bootstrap",
                            Order = 5,
                        },
                        new () {
                            Name = "HTML",
                            Order = 1,
                        },
                        new () {
                            Name = "CSS",
                            Order = 2,
                        },
                        new() {
                            Name = "JavaScript",
                            Order = 3,
                        }
                    }
                },
                new SkillGroup
                {
                    Id = skillGroupCounter++,
                    Name = "Unit Testing",
                    Order = skillGroupOrderCounter++,
                    Skills = new()
                    {
                       new() {
                           Name = "Dependency Injection",
                           Order = 1
                       },
                       new() {
                            Name = "NUnit",
                            Order = 2,
                        },
                        new () {
                            Name = "Moq",
                            Order = 3,
                        }
                    }
                },
                new SkillGroup
                {
                    Id = skillGroupCounter++,
                    Name = "Source Control",
                    Order = skillGroupOrderCounter++,
                    Skills = new()
                    {
                       new() {
                           Name = "Azure DevOps",
                           Order = 1
                       },
                       new() {
                            Name = "Git",
                            Order = 2,
                        },
                        new () {
                            Name = "TFS",
                            Order = 3,
                        }
                    }
                },
                new SkillGroup
                {
                    Id = skillGroupCounter++,
                    Name = "Backend",
                    Order = skillGroupOrderCounter++,
                    Skills = new()
                    {
                       new() {
                           Name = "Active Directory",
                           Order = 1
                       },
                       new() {
                            Name = "Exchange",
                            Order = 2,
                        },
                        new () {
                            Name = "CXT (Logistics Software)",
                            Order = 3,
                        }
                    }
                },
            };

            return skillGroups;
        }
    }
}

