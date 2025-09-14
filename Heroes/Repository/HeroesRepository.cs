using Domain;
using Heroes.Database;
using Heroes.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class HeroesRepository: IHeroesRepository
    {
        private readonly HeroesDbContext _context;

        public HeroesRepository(HeroesDbContext context)
        {
            _context = context;
        }

        public async Task<List<HeroeDomain>> GetAllAsync()
        {
            return await _context.Set<HeroeDomain>().ToListAsync();
        }

        public async Task<HeroeDomain> GetByIdAsync(int id)
        {
            return await _context.Set<HeroeDomain>().FindAsync(id);
        }

        public async Task Create(HeroeDomain entity)
        {
            _context.Set<HeroeDomain>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<HeroeDomain>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<HeroeDomain>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}