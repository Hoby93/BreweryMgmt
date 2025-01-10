using BreweryManagementAPI.Domain.Entities;

namespace BreweryManagementAPI.Domain.Interfaces
{
    public interface IBreweryRepository
    {
        Task<List<Brewery>> GetAllBeersByBreweryAsync();
    }
}