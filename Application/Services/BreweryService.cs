using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using BreweryManagementAPI.Domain.Entities;
using BreweryManagementAPI.Infrastructure.Persistence;

namespace BreweryManagementAPI.Application.Services
{
    public class BreweryService
    {
        private readonly BreweryContext _context;

        public BreweryService(BreweryContext context)
        {
            _context = context;
        }

        public List<Brewery> GetAllBeersByBrewery()
        {
            // Utilisation de Include pour charger les brasseries et leurs brasseurs, puis les bières associées
            var breweries = _context.Breweries
                .Include(b => b.Brewers)  // Charger les brasseurs associés à chaque brasserie
                .ThenInclude(br => br.Beers)  // Charger les bières associées à chaque brasseur
                .ToList();  // Exécute la requête et retourne la liste de brasseries avec leurs bières

            return breweries;
        }
    }
}
