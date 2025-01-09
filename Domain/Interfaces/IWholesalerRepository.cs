using BreweryManagementAPI.Domain.Entities;

namespace BreweryManagementAPI.Domain.Interfaces
{
    public interface IWholesalerRepository
    {
        Task AddStockActionAsync(WholesalerStock stockAction);
        Task<int> GetBeerStockBalanceAsync(int wholesalerId, int beerId);
        Task<bool> IsWholesalerExistAsync(int wholesalerId);
        Task CheckBeerStockAsync(int wholesalerId, OrderDetail order);
    }
}
