using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using Services.Interfaces;

namespace Services.Interfaces
{
    public interface IHeroService
    {
        Task AddAsync(HeroeDomain entity);
        Task DeleteAsync(int id);
        Task<HeroeDomain> GetByIdAsync(int id);
        Task<List<HeroeDomain>> GetAllAsync();
    }
}