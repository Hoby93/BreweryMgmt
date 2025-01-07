using BreweryManagementAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BreweryManagementAPI.Infrastructure.Persistence
{
    public class BreweryContext : DbContext
    {
        public BreweryContext(DbContextOptions<BreweryContext> options) : base(options) { }

        public DbSet<Beer> Beers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // modelBuilder.Entity<Beer>().ToTable("Beer");
        }
    }
}
