using PortfolioApi.Models;

namespace PortfolioApi.Persistence.Repositories
{
    public interface IRepository<T> where T : IOwnedItem
    {
        Task<List<T>> GetByOwner(string ownerId);
    }
}