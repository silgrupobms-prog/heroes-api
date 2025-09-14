using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Infrastructure;

public class HeroesDbContextFactory : IDesignTimeDbContextFactory<HeroesDbContext>
{
    public HeroesDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<HeroesDbContext>();

        // Coloque aqui a sua connection string do PostgreSQL
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=heroes;Username=postgres;Password=1234");

        return new HeroesDbContext(optionsBuilder.Options);
    }
}
