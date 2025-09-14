using Domain;

namespace Services.Interfaces
{
    public interface IHeroPowerService
    {
        Task AddAsync(HeroPowerDomain entity);
        Task<List<HeroPowerDomain>> GetByHeroIdAsync(int heroId);
        Task DeleteAsync(int heroId, int powerId);
    }
}