using Domain;
using Dtos;
using Heroes.Repository.Interfaces;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class GetHeroesService : IGetHeroeService
    {
        private readonly IHeroesRepository _heroesRepository;

        public GetHeroesService(IHeroesRepository heroesRepository)
        {
            _heroesRepository = heroesRepository;
        }

        public async Task<IEnumerable<GetHeroesDto>> Perform()
        {
            var entity = await _heroesRepository.GetAllAsync();

            if (entity == null)
            {
                return new List<GetHeroesDto>();
            }

            return entity.Select(h => new GetHeroesDto
            {
                Id = h.Id,
                Name = h.Name,
                Description = h.Description,
                DateOfBirth = h.DateOfBirth,
                Height = h.Height,
                Weight = h.Weight
                
            }).ToList();
        }

        internal async Task DeleteAsync(int heroIdToDelete)
        {
            throw new NotImplementedException();
        }

        internal async Task<IAsyncEnumerable<HeroeDomain>?> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}