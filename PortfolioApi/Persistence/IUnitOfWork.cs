using PortfolioApi.DTOs;
using PortfolioApi.Persistence.Repositories;

namespace PortfolioApi.Persistence
{
    public interface IUnitOfWork
    {
        IRepository<EducationExperience> EducationExperiences { get; init; }
        IRepository<WorkExperience> WorkExperiences { get; init; }
        IRepository<SkillGroup> SkillGroups { get; init; }
        IProjectRepository Projects { get; init; }
        IPersonProfileRepository PersonProfiles { get; init; }
    }
}