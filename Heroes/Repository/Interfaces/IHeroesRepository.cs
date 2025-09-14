using Domain;

namespace Heroes.Repository.Interfaces
{
    public interface IHeroesRepository
    {
        Task<List<HeroeDomain>> GetAllAsync();
        Task<HeroeDomain> GetByIdAsync(int id);
        Task Create(HeroeDomain entity);
        Task DeleteAsync(int id);
    }
}