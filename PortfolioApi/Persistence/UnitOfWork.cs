using System;
using PortfolioApi.DTOs;
using PortfolioApi.Persistence.Repositories;

namespace PortfolioApi.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRepository<EducationExperience> EducationExperiences { get; init; }
        public IRepository<WorkExperience> WorkExperiences { get; init; }
        public IRepository<SkillGroup> SkillGroups { get; init; }
        public IProjectRepository Projects { get; init; }
        public IPersonProfileRepository PersonProfiles { get; init; }

        public UnitOfWork()
        {
            //get from env
            string accountEndpoint = "a";
            string authKeyOrResourceToken = "b";
            string databaseId = "c";

            CosmosConfig cosmosConfig = new(accountEndpoint, authKeyOrResourceToken, databaseId);

            EducationExperiences = new Repository<EducationExperience>(cosmosConfig, "education-experiences");
            WorkExperiences = new Repository<WorkExperience>(cosmosConfig, "work-experiences");
            SkillGroups = new Repository<SkillGroup>(cosmosConfig, "skill-groups");
            Projects = new ProjectRepository(cosmosConfig, "projects");
            PersonProfiles = new PersonProfileRepository(cosmosConfig, "person-profiles");
        }
    }
}

