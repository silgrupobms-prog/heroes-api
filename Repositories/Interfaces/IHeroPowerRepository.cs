using Models;

namespace Repositories.Interfaces
{
    public interface IHeroPowerRepository
    {
        Task AddAsync(HeroPower entity);
        Task<List<HeroPower>> GetByHeroId(int heroId);
        Task DeleteAsync(int heroId, int powerId);
    }
}