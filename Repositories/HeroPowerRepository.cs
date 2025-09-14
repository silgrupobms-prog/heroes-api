using Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Repositories
{
    public class HeroPowerRepository : IHeroPowerRepository
    {
        private readonly HeroesDbContext _context;

        public HeroPowerRepository(HeroesDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(HeroPower entity)
        {
            _context.Set<HeroPower>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<HeroPower>> GetByHeroId(int heroId)
        {
            return await _context.Set<HeroPower>()
                .Include(hp => hp.Hero)
                .Include(hp => hp.Power)
                .Where(hp => hp.HeroId == heroId)
                .ToListAsync();
        }

        public async Task DeleteAsync(int heroId, int powerId)
        {
            var entity = await _context.Set<HeroPower>().FindAsync(heroId, powerId);
            if (entity != null)
            {
                _context.Set<HeroPower>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}