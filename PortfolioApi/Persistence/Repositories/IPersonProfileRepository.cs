using PortfolioApi.DTOs;

namespace PortfolioApi.Persistence.Repositories
{
    public interface IPersonProfileRepository
    {
        Task<PortfolioPersonProfile?> GetNewestByOwner(string ownerId);
    }
}