using BreweryManagementAPI.Domain.Entities;

namespace BreweryManagementAPI.Domain.Interfaces
{
    public interface IBeerRepository
    {
        Task<IEnumerable<Beer>> GetAllAsync();
        Task<Beer> GetByIdAsync(int id);
        Task AddAsync(Beer beer);
        Task UpdateAsync(Beer beer);
        Task DeleteAsync(int id);
        Task<Dictionary<int, decimal>> GetBeerPricesAsync(IEnumerable<OrderDetail> orderDetails);
    }
}
