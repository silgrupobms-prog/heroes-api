using Models;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services
{
    public class HeroPowerService : IHeroPowerService
    {
        private readonly IHeroPowerRepository _heroPowerRepository;

        public HeroPowerService(IHeroPowerRepository heroPowerRepository)
        {
            _heroPowerRepository = heroPowerRepository;
        }

        public async Task AddAsync(HeroPower entity)
        {
            await _heroPowerRepository.AddAsync(entity);
        }

        public async Task<List<HeroPower>> GetByHeroId(int heroId)
        {
            return await _heroPowerRepository.GetByHeroId(heroId);
        }

        public async Task DeleteAsync(int heroId, int powerId)
        {
            await _heroPowerRepository.DeleteAsync(heroId, powerId);
        }
    }
}