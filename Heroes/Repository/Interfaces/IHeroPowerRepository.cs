using Domain;

namespace Heroes.Repository.Interfaces
{
    public interface IHeroPowerRepository
    {
        Task AddAsync(HeroPowerDomain entity);
        Task<List<HeroPowerDomain>> GetByHeroIdAsync(int heroId);
        Task DeleteAsync(int heroId, int powerId);
    }
}
