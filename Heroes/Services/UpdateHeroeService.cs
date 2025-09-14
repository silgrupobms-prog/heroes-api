using Domain;
using Dtos;
using Heroes.Repository.Interfaces;
using Services.Interfaces;

namespace Services
{
    public class UpdateHeroeService : IUpdateHeroeService
    {
        private readonly IHeroesRepository _heroesRepository;

        public UpdateHeroeService(IHeroesRepository heroesRepository)
        {
            _heroesRepository = heroesRepository;
        }

        public async Task Perform(int id, UpdateHeroDto hero)
        {
            var existingHero = await _heroesRepository.GetByIdAsync(id);
            if (existingHero == null)
            {
                throw new ArgumentException($"Herói com ID {id} não encontrado.");
            }

            existingHero.Name = hero.Name;
            existingHero.Description = hero.Description;
            existingHero.Weight = hero.Weight;
            existingHero.Height = hero.Height;
            existingHero.DateOfBirth = hero.DateOfBirth;

            await _heroesRepository.UpdateAsync(existingHero);
        }
    }
} 