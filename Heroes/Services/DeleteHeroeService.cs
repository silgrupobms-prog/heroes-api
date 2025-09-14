using Heroes.Repository.Interfaces;
using Services.Interfaces;

namespace Services
{
    public class DeleteHeroeService : IDeleteHeroeService
    {
        private readonly IHeroesRepository _heroesRepository;

        public DeleteHeroeService(IHeroesRepository heroesRepository)
        {
            _heroesRepository = heroesRepository;
        }

        public async Task Perform(int id)
        {
            await _heroesRepository.DeleteAsync(id);
        }
    }
}