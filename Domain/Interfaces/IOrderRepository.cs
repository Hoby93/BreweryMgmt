using BreweryManagementAPI.Domain.Entities;

namespace BreweryManagementAPI.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task CheckOrderAsync(IWholesalerRepository _rwholesaler, Order order);
    }
}