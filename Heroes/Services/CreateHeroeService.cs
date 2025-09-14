using Domain;
using Dtos;
using Heroes.Repository.Interfaces;
using Services.Interfaces;

namespace Services
{
    public class CreateHeroeService : ICreateHeroeService
    {
        private readonly IHeroesRepository _heroesRepository;

        public CreateHeroeService(IHeroesRepository heroesRepository)
        {
            _heroesRepository = heroesRepository;
        }

        public async Task Perform(CreateHeroDto hero)
        {
            var entity = new HeroeDomain
            {
                Name = hero.Name,
                Description = hero.Description,
                Weight = hero.Weight,
                Height = hero.Height,
                DateOfBirth = hero.DateOfBirth,
            };

            await _heroesRepository.Create(entity);
        }
    }
}