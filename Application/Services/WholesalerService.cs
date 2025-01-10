using BreweryManagementAPI.Domain.Entities;
using BreweryManagementAPI.Domain.Interfaces;

namespace BreweryManagementAPI.Application.Services
{
    public class WholesalerService
    {
        private readonly IWholesalerRepository _rwholesaler;
        private readonly IBeerRepository _rbeer;
        private readonly IOrderRepository _rorder;

        public WholesalerService(IWholesalerRepository rwholesaler, IBeerRepository rbeer, IOrderRepository rorder)
        {
            _rwholesaler = rwholesaler;
            _rbeer = rbeer;
            _rorder = rorder;
        }

        public async Task AddWholesalerStockAtionAsync(WholesalerStock stockAction)
        {
            await _rwholesaler.AddStockActionAsync(stockAction);
        }

        public async Task<decimal> GetOrderQuoteAsync(Order order)
        {
            try {
                await _rorder.CheckOrderAsync(_rwholesaler, order); // Verifier la commande

                // Appel au repository pour récupérer les prix des bières
                Dictionary<int, decimal> prices = await _rbeer.GetBeerPricesAsync(order.OrderDetails);

                foreach (OrderDetail detail in order.OrderDetails)
                {
                    await _rwholesaler.CheckBeerStockAsync(order.WholesalerId, detail); // Verifier l'etat de stock

                    order.SetDevisDetails(detail.Quantity * prices[detail.BeerId], detail.Quantity);
                }
            } catch(Exception e) {
                throw e;
            }

            return order.GetDevis();
        }
 
    }
}
