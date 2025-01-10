using BreweryManagementAPI.Domain.Entities;
using BreweryManagementAPI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BreweryManagementAPI.Infrastructure.Persistence
{
    public class BreweryRepository : IBreweryRepository
    {
        private readonly BreweryContext _context;

        public BreweryRepository(BreweryContext context)
        {
            _context = context;
        }

        public async Task<List<Brewery>> GetAllBeersByBreweryAsync()
        {
            // Charger les brasseries avec leurs brasseurs et bières associées
            var breweries = await _context.Breweries
                .Include(b => b.Brewers) // Charger les brasseurs
                .ThenInclude(br => br.Beers) // Charger les bières des brasseurs
                .ToListAsync(); // Exécuter la requête et obtenir une liste

            return breweries;
        }
    }
}