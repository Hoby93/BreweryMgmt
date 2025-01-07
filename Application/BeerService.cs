using BreweryManagementAPI.Domain.Entities;
using BreweryManagementAPI.Domain.Interfaces;

namespace BreweryManagementAPI.Application.Services
{
    public class BeerService
    {
        private readonly IBeerRepository _repository;

        public BeerService(IBeerRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Beer>> GetAllBeersAsync() => await _repository.GetAllAsync();

        public async Task<Beer> GetBeerByIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task AddBeerAsync(Beer beer) => await _repository.AddAsync(beer);

        public async Task UpdateBeerAsync(Beer beer) => await _repository.UpdateAsync(beer);

        public async Task DeleteBeerAsync(int id) => await _repository.DeleteAsync(id);
    }
}
