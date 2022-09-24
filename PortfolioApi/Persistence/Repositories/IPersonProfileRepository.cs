using PortfolioApi.Models;

namespace PortfolioApi.Persistence.Repositories
{
    public interface IPersonProfileRepository
    {
        Task<PortfolioPersonProfile?> GetNewestByOwner(string ownerId);
    }
}