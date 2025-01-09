using BreweryManagementAPI.Domain.Entities;
using BreweryManagementAPI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BreweryManagementAPI.Infrastructure.Persistence
{
    public class WholesalerRepository : IWholesalerRepository
    {
        private readonly BreweryContext _context;

        public WholesalerRepository(BreweryContext context)
        {
            _context = context;
        }

        public async Task AddStockActionAsync(WholesalerStock stockAction)
        {
            // Ajout de l'entité dans le DbSet correspondant
            await _context.WholesalerStocks.AddAsync(stockAction);
            
            // Enregistrement des modifications dans la base de données
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsWholesalerExistAsync(int wholesalerId)
        {
            return await _context.Wholesalers
                .AnyAsync(w => w.Id == wholesalerId);
        }

        public async Task<int> GetBeerStockBalanceAsync(int wholesalerId, int beerId)
        {
            // Vérifier s'il y a des lignes correspondantes dans la table
            bool exists = await _context.WholesalerStocks
                .AnyAsync(ws => ws.WholesalerId == wholesalerId && ws.BeerId == beerId);

            if (!exists)
            {
                return -1; // Retourner -1 si aucune ligne correspondante n'est trouvée
            }

            // Récupérer la dernière date d'action où Action = 2 pour le grossiste et la bière spécifiés
            var lastReportDate = (await _context.WholesalerStocks
                .Where(ws => ws.WholesalerId == wholesalerId && ws.BeerId == beerId && ws.Action == 2)
                .MaxAsync(ws => (DateTime?)ws.ActionDate))?.ToUniversalTime() ?? DateTime.MinValue;


            // Calculer le solde de stock à partir de cette date
            var stockBalance = await _context.WholesalerStocks
                .Where(ws => ws.WholesalerId == wholesalerId && ws.BeerId == beerId && ws.ActionDate >= lastReportDate)
                .SumAsync(ws => ws.Action == 0 ? -ws.Quantity : ws.Quantity);

            return stockBalance;
        }

        // Méthode statique pour récupérer le stock d'une bière
        public async Task CheckBeerStockAsync(int wholesalerId, OrderDetail order)
        {
            // Récupérer le stock actuel pour la bière
            int restOnStock = await this.GetBeerStockBalanceAsync(wholesalerId, order.BeerId);

            // Si la biere n'est pas disponible, lever une exception
            if (restOnStock == -1)
            {
                throw new Exception($"Cette bière n'est pas disponible.");
            }

            // Si la quantité demandée est supérieure au stock disponible, lever une exception
            if (order.Quantity > restOnStock)
            {
                throw new Exception($"Quantité insuffisante pour la bière {order.BeerId}. Stock disponible : {restOnStock}.");
            }
        }
    }
}