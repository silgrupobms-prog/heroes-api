using Models;

namespace Services.Interfaces
{
    public interface IHeroPowerService
    {
        Task AddAsync(HeroPower entity);
        Task<List<HeroPower>> GetByHeroId(int heroId);
        Task DeleteAsync(int heroId, int powerId);
    }
}