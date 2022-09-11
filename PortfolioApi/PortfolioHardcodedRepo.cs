using System;
using System.Xml.Linq;
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
                    Skills = new Skill[]
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
                    Skills = new Skill[]
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
                    Skills = new Skill[]
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
                    Skills = new Skill[]
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
                    Skills = new Skill[]
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

        public static List<EducationExperience> GetEducationExperiences()
        {
            return new List<EducationExperience>()
            {
                new()
                {
                    Id = 1,
                    SchoolName = "University of Houston-Downtown",
                    Degree = "Bachelor of Science in Computer Science",
                    YearOfGraduation = 2017,
                    EducationCourses = new EducationCourse[] {
                        new() {
                            Name = "Software Engineering",
                            Order = 1
                        },
                        new() {
                            Name = "Data Structures and Algorithms",
                            Order = 2
                        },
                        new() {
                            Name = "Object Oriented Programming",
                            Order = 3
                        },
                        new() {
                            Name = "Database and Warehouses",
                            Order = 4
                        }
                    },
                    City = "Houston",
                    State = "TX"
                }
            };
        }

        public static PortfolioPersonProfile? GetPortfolioPersonProfile()
        {
            PortfolioPersonProfile[] personProfiles = new PortfolioPersonProfile[] {
                new() {
                    Name = "Ismael Almaguer",
                    CareerTitle = "Full Stack Web Developer",
                    PictureSrc = "./images/my-picture.jpeg",
                    ProfileLinks = new BasicHyperLink[] {
                        new() {
                            DisplayText = "Résumé",
                            Href = "https://example.com",
                            Order = 1
                        },
                        new() {
                            DisplayText = "LinkedIn",
                            Href = "https://linkedin.com",
                            Order = 2
                        },
                        new() {
                            DisplayText = "GitHub",
                            Href = "https://github.com",
                            Order = 3
                        }
                    },
                    CreatedDateTime = DateTimeOffset.Now
                }
            };

            return personProfiles.OrderByDescending(personProfile => personProfile.CreatedDateTime).FirstOrDefault();
        }

        public static List<WorkExperience> GetWorkExperiences()
        {
            int workExperienceCounter = 1;

            return new()
            {
                new() {
                    Id = workExperienceCounter++,
                    CompanyName = "BakerRipley",
                    City = "Houston",
                    State = "TX",
                    StartDate = new DateOnly(2021, 10, 1),
                    Title = "Software Developer",
                    WorkResponsibilities = new WorkResponsibility[] {
                        new() {
                            Description = "Refactor and document existing .NET applications so that they are more understandable and maintainable.",
                            Order = 1
                        },
                        new() {
                            Description = "Utilize Azure DevOps to document work items, check in changesets, and deploy using Continuous Integration.",
                            Order = 2
                        },
                        new() {
                            Description = "Lead a team of junior developers and collaborate on tasks with them.",
                            Order = 3
                        }
                    }
                },
                new() {
                    Id = workExperienceCounter++,
                    CompanyName = "Diligent Delivery Systems",
                    City = "Houston",
                    State = "TX",
                    StartDate = new DateOnly(2019, 5, 1),
                    EndDate = new DateOnly(2022, 10, 1),
                    Title = "Full Stack Web Developer",
                    WorkResponsibilities = new WorkResponsibility[] {
                        new() {
                            Description = "Created new applications for our clients and employees with modern frameworks such as Entity Framework, Web API 2, and ReactJS.",
                            Order = 1
                        },
                        new() {
                            Description = "Maintained and developed new features for our custom logistics software utilizing SQL and ASP.NET Web Forms.",
                            Order = 2
                        },
                        new() {
                            Description = "Assisted operations and accounting with data analysis by providing custom reports via SQL queries.",
                            Order = 3
                        }
                    }
                }
            };
        }

        public static List<Project> GetPersonalProjects()
        {
            int projectIdCounter = 1;

            return new()
            {
                new() {
                    Id = projectIdCounter++, 
                    Title = "Image Converter",
                    Description = "A console and web application that converts images from one format to another. Both projects utilize a shared .NET standard library.",
                    ProjectTeches = new ProjectTech[] { 
                        new() {
                            Name = "C#",
                            Order = 1
                        },
                        new() {
                            Name = ".NET 6",
                            Order = 2
                        },
                        new() {
                            Name = ".NET MVC",
                            Order = 3
                        },
                        new() {
                            Name = "NUnit",
                            Order = 4
                        },
                        new() {
                            Name = "Moq",
                            Order = 5
                        },
                        new() {
                            Name = "Bootstrap",
                            Order = 6
                        },
                    },
                    ProjectLinks = new BasicHyperLink[] {
                        new() {
                            Href = "https://github.com/smael123/ImageConverter",
                            DisplayText = "Source Code",
                            Order = 1
                        }
                    }
                },
                new() {
                    Id = projectIdCounter++, 
                    Title = "Restaurant Website",
                    Description = "A website made using .NET MVC for a fictional restaurant. Has a manager portal with the ability for managers to add food and specials.",
                    ProjectTeches = new ProjectTech[] {
                        new() {
                            Name = "ASP.NET MVC",
                            Order = 1
                        },
                        new() {
                            Name = "ASP.NET Identity",
                            Order = 2,
                        },
                        new() {
                            Name = "Entity Framework",
                            Order = 3,
                        },
                        new() {
                            Name = "Microsoft SQL",
                            Order = 4,
                        },
                        new() {
                            Name = "Bootstrap",
                            Order = 5,
                        },
                    },
                    ProjectLinks = new BasicHyperLink[] {
                        new() {
                            Href = "https://github.com/smael123/RestaurantWebsite",
                            DisplayText = "Source Code",
                            Order = 1
                        }
                    }
                },
                new() {
                    Id = projectIdCounter++, 
                    Title = "Password Generator React",
                    Description = "A React application that allows you to generate a random password.",
                    ProjectTeches = new ProjectTech[] {
                        new() {
                            Name = "React",
                            Order = 1
                        },
                        new() {
                            Name = "React Hooks",
                            Order = 2
                        },
                    },
                    ProjectLinks = new BasicHyperLink[] {
                        new() {
                            Href = "https://github.com/smael123/PasswordGeneratorReact",
                            DisplayText = "Source Code",
                            Order = 1
                        }
                    }
                },
                new() {
                    Id = projectIdCounter++, 
                    Title = "Password Generator App",
                    Description = "A Xamarin mobile application for Android allows you to generate a random password.",
                    ProjectTeches = new ProjectTech[] {
                        new() {
                            Name = "Xamarin Forms",
                            Order = 1
                        }
                    },
                    ProjectLinks = new BasicHyperLink[] {
                        new() {
                            Href = "https://github.com/smael123/PasswordGeneratorApp",
                            DisplayText = "Source Code",
                            Order = 1
                        }
                    }
                },
                new() {
                    Id = projectIdCounter++, 
                    Title = "Hangman React",
                    Description = "A hangman game implemented using React",
                    ProjectTeches = new ProjectTech[] {
                        new() {
                            Name = "React",
                            Order = 1
                        },
                    },
                    ProjectLinks = new BasicHyperLink[] {
                        new() {
                            Href = "https://github.com/smael123/HangmanReact",
                            DisplayText = "Source Code",
                            Order = 1
                        }
                    }
                },
            };
        }

        public static List<Project> GetWorkProjects()
        {
            int workProjectIdCounter = 1;

            return new()
            {
                new() {
                    Id = workProjectIdCounter++, 
                    Title = "Employee Onboarding Application",
                    CompanyName = "BakerRipley",
                    Description = "Worked on a general refactor of our Employee Onboarding application. Moved logic that talked to external systems (e.g. Active Directory, Exchange Server, network drives) to its own classes. This refactor reduced the development time needed when we switched over from on premises Exchange Online.",
                    ProjectTeches = new ProjectTech[] {
                        new() {
                            Name = "C#",
                            Order = 1
                        },
                        new() {
                            Name = "PowerShell",
                            Order = 2
                        },
                        new() {
                            Name = "SQL",
                            Order = 3
                        },
                        new() {
                            Name = "Active Directory",
                            Order = 4
                        },
                        new() {
                            Name = "Exchange",
                            Order = 5
                        }
                    }
                },
                new() {
                    Id = workProjectIdCounter++,
                    Title = "Client Portal Application",
                    CompanyName = "Diligent Delivery Systems",
                    Description = "Re-engineered our current network delivery portal with a .NET Web API 2 backend and a React frontend. Converted stored procedure and code-file SQL queries to Entity Framework methods. Also directed junior developers by assigning them a set of the application’s features and conveying the requirements via written documentation and oral conversations.",
                    ProjectTeches = new ProjectTech[] {
                        new() {
                            Name = ".NET Web API 2",
                            Order = 1
                        },
                        new() {
                            Name = "React",
                            Order = 2
                        },
                        new() {
                            Name = "Entity Framework",
                            Order = 3
                        },
                        new() {
                            Name = "Bootstrap",
                            Order = 4
                        },
                        new() {
                            Name = "Nlog",
                            Order = 5
                        },
                    }
                },
                new () {
                    Id = workProjectIdCounter++, 
                    Title = "Reschedule Application",
                    CompanyName = "Diligent Delivery Systems",
                    Description = "Designed a mobile friendly web application to allow our employees to reschedule deliveries on the warehouse. This reduced the overall process time by eliminating the need to reschedule it on the desktop only web application.",
                    ProjectTeches = new ProjectTech[] {
                        new() {
                            Name = ".NET Web API 2",
                            Order = 1
                        },
                        new() {
                            Name = "React",
                            Order = 2
                        },
                        new() {
                            Name = "Entity Framework",
                            Order = 3
                        },
                        new() {
                            Name = "Bootstrap",
                            Order = 4
                        },
                        new() {
                            Name = "Nlog",
                            Order = 5
                        },
                    }
                },
                new() {
                    Id = workProjectIdCounter++, 
                    Title = "Live Tracking Service",
                    CompanyName = "Diligent Delivery Systems",
                    Description = "Designed a Windows service that periodically sends package scan updates to an external logistics system.",
                    ProjectTeches = new ProjectTech[] {
                        new() {
                            Name = "Entity Framework",
                            Order = 1
                        },
                        new() {
                            Name = "Nlog",
                            Order = 2,
                        },
                        new() {
                            Name = "CXT (Logistics Software)",
                            Order = 3,
                        },
                    }
                }
            };
        }
    }
}