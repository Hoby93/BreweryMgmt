using BreweryManagementAPI.Domain.Entities;
using BreweryManagementAPI.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BreweryManagementAPI.Application.Services
{
    public class BreweryService
    {
        private readonly IBreweryRepository _breweryRepository;

        public BreweryService(IBreweryRepository breweryRepository)
        {
            _breweryRepository = breweryRepository;
        }

        public async Task<List<Brewery>> GetBreweriesWithBeersAsync()
        {
            // Appel au repository pour obtenir les brasseries avec leurs bières
            return await _breweryRepository.GetAllBeersByBreweryAsync();
        }
    }
}
