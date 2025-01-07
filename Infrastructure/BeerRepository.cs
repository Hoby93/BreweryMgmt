using BreweryManagementAPI.Domain.Entities;
using BreweryManagementAPI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BreweryManagementAPI.Infrastructure.Persistence
{
    public class BeerRepository : IBeerRepository
    {
        private readonly BreweryContext _context;

        public BeerRepository(BreweryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Beer>> GetAllAsync()
        {
            return await _context.Beers.ToListAsync();
        }

        public async Task<Beer> GetByIdAsync(int id)
        {
            return await _context.Beers.FindAsync(id);
        }

        public async Task AddAsync(Beer beer)
        {
            await _context.Beers.AddAsync(beer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Beer beer)
        {
            _context.Beers.Update(beer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var beer = await _context.Beers.FindAsync(id);
            if (beer != null)
            {
                _context.Beers.Remove(beer);
                await _context.SaveChangesAsync();
            }
        }
    }
}