using Heroes.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class HeroesDbContextFactory : IDesignTimeDbContextFactory<HeroesDbContext>
{
    public HeroesDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory()) 
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("Postgresql");

        var optionsBuilder = new DbContextOptionsBuilder<HeroesDbContext>();
        optionsBuilder.UseNpgsql(connectionString);

        return new HeroesDbContext(optionsBuilder.Options);
    }
}
