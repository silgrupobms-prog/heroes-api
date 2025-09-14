using Domain;
using Heroes.Repository.Interfaces;
using Services.Interfaces;

namespace Services
{
    public class GetHeroeByIdService : IGetHeroeByIdService
    {
        private readonly IHeroesRepository _heroesRepository;

        public GetHeroeByIdService(IHeroesRepository heroesRepository)
        {
            _heroesRepository = heroesRepository;
        }

        public async Task<HeroeDomain> Perform(int id)
        {
            return await _heroesRepository.GetByIdAsync(id);
        }

        internal async Task<IAsyncEnumerable<object>> GetByIdAsync(int v)
        {
            throw new NotImplementedException();
        }
    }
}