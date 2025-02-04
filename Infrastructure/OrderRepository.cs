using BreweryManagementAPI.Domain.Entities;
using BreweryManagementAPI.Domain.Interfaces;

namespace BreweryManagementAPI.Infrastructure.Persistence
{
    public class OrderRepository : IOrderRepository
    {

        // Méthode statique pour récupérer le stock d'une bière
        public async Task CheckOrderAsync(IWholesalerRepository _rwholesaler, Order order)
        {
            bool isWholesalerExist = await _rwholesaler.IsWholesalerExistAsync(order.WholesalerId);
            bool hasDuplicatedBeer = order.OrderDetails
                .GroupBy(od => od.BeerId)
                .Any(group => group.Count() > 1);
            
            if(!isWholesalerExist) {
                throw new Exception("The wholesaler must exist.");
            }
            if(!order.OrderDetails.Any()) {
                throw new Exception("The order cannot be empty");
            }
            if(hasDuplicatedBeer) {
                throw new Exception("The order cannot contain duplicates beers.");
            }
        }
    }
}