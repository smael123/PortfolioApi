using PortfolioApi.Models;

namespace PortfolioApi.Persistence.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetProjectsByOwnerAndType(string ownerId, string projectType);
    }
}