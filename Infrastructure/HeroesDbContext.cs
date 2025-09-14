using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure
{
    public class HeroesDbContext : DbContext
    {
        public DbSet<HeroesDomain> Heroes {  get; set; }

        public HeroesDbContext(DbContextOptions<HeroesDbContext> options)
             : base(options)
        {
        }

    }
}
