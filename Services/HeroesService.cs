using Domain;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class HeroesService
    {
        private readonly HeroesDbContext _context;

        public HeroesService(HeroesDbContext context)
        {
            _context = context;
        }

        // Adiciona um poder ao herói
        public async Task AddPowerToHeroAsync(int heroeId, int powerId)
        {
            var heroPower = new HeroPowerDomain
            {
                HeroeId = heroeId,
                PowerId = powerId
            };
            _context.Set<HeroPowerDomain>().Add(heroPower);
            await _context.SaveChangesAsync();
        }

        // Remove um poder do herói
        public async Task RemovePowerFromHeroAsync(int heroeId, int powerId)
        {
            var heroPower = await _context.Set<HeroPowerDomain>()
                .FirstOrDefaultAsync(hp => hp.HeroeId == heroeId && hp.PowerId == powerId);

            if (heroPower != null)
            {
                _context.Set<HeroPowerDomain>().Remove(heroPower);
                await _context.SaveChangesAsync();
            }
        }

        // Lista todos os poderes de um herói
        public async Task<List<PowerDomain>> GetPowersByHeroAsync(int heroeId)
        {
            return await _context.Set<HeroPowerDomain>()
                .Where(hp => hp.HeroeId == heroeId)
                .Include(hp => hp.Power)
                .Select(hp => hp.Power)
                .ToListAsync();
        }
    }
}