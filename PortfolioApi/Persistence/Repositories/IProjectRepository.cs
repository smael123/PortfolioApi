using PortfolioApi.DTOs;

namespace PortfolioApi.Persistence.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetProjectsByOwnerAndType(string ownerId, string projectType);
    }
}