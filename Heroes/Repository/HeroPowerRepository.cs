using Domain;
using Heroes.Database;
using Heroes.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class HeroPowerRepository : IHeroPowerRepository
    {
        private readonly HeroesDbContext _context;

        public HeroPowerRepository(HeroesDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(HeroPowerDomain entity)
        {
            _context.Set<HeroPowerDomain>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<HeroPowerDomain>> GetByHeroIdAsync(int heroId)
        {
            return await _context.Set<HeroPowerDomain>()
                .Include(hp => hp.Heroe)
                .Include(hp => hp.Power)
                .Where(hp => hp.HeroeId == heroId)
                .ToListAsync(); // Sempre retorna uma lista, nunca null
        }

        public async Task DeleteAsync(int heroId, int powerId)
        {
            var entity = await _context.Set<HeroPowerDomain>().FindAsync(heroId, powerId);
            if (entity != null)
            {
                _context.Set<HeroPowerDomain>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}