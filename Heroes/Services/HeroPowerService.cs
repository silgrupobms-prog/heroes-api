using Domain;
using Heroes.Repository.Interfaces;
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

        public async Task AddAsync(HeroPowerDomain entity)
        {
            await _heroPowerRepository.AddAsync(entity);
        }

        public async Task<List<HeroPowerDomain>> GetByHeroIdAsync(int heroId)
        {
            return await _heroPowerRepository.GetByHeroIdAsync(heroId); // Sempre uma lista
        }

        public async Task DeleteAsync(int heroId, int powerId)
        {
            await _heroPowerRepository.DeleteAsync(heroId, powerId);
        }
    }
}