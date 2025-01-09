using BreweryManagementAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BreweryManagementAPI.Infrastructure.Persistence
{
    public class BreweryContext : DbContext
    {
        public BreweryContext(DbContextOptions<BreweryContext> options) : base(options) { }

        public DbSet<Brewery> Breweries { get; set; }
        public DbSet<Brewer> Brewers { get; set; }
        public DbSet<Beer> Beers { get; set; }
        public DbSet<WholeSaler> Wholesalers { get; set; }
        public DbSet<WholesalerStock> WholesalerStocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
