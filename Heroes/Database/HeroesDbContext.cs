using Domain;
using Microsoft.EntityFrameworkCore;

namespace Heroes.Database
{
    public class HeroesDbContext : DbContext
    {
        public DbSet<HeroeDomain> Heroes {  get; set; }
        public DbSet<PowerDomain> Power {  get; set; }
        public DbSet<HeroPowerDomain> HeroPower { get; set; }

        public HeroesDbContext(DbContextOptions<HeroesDbContext> options)
             : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HeroeDomain>(entity =>
            {
                entity.ToTable("heroes");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Description).HasColumnName("description");
                entity.Property(e => e.DateOfBirth).HasColumnName("date_of_birth");
                entity.Property(e => e.Height).HasColumnName("height");
                entity.Property(e => e.Weight).HasColumnName("weight");
            });

            modelBuilder.Entity<PowerDomain>(entity =>
            {
                entity.ToTable("power");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                      .HasColumnName("id")
                      .ValueGeneratedOnAdd();

                entity.Property(e => e.Superpower)
                      .HasColumnName("superpower")
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(e => e.Description)
                      .HasColumnName("description")
                      .HasMaxLength(250);
            });

            modelBuilder.Entity<HeroPowerDomain>(entity =>
            {
                entity.ToTable("hero_power");

                entity.HasKey(e => new { e.HeroeId, e.PowerId });

                entity.Property(e => e.HeroeId).HasColumnName("heroe_id");
                entity.Property(e => e.PowerId).HasColumnName("power_id");

                entity.HasOne(e => e.Heroe)
                      .WithMany(h => h.HeroePowers)
                      .HasForeignKey(e => e.HeroeId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Power)
                      .WithMany(p => p.HeroPowers)
                      .HasForeignKey(e => e.PowerId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<PowerDomain>().HasData(
                new PowerDomain { Id = 1, Superpower = "Super Força", Description = "Capacidade de levantar objetos extremamente pesados." },
                new PowerDomain { Id = 2, Superpower = "Voo", Description = "Capacidade de voar em altas velocidades." },
                new PowerDomain { Id = 3, Superpower = "Invisibilidade", Description = "Pode ficar invisível à vontade." },
                new PowerDomain { Id = 4, Superpower = "Telepatia", Description = "Capacidade de ler e comunicar-se com a mente." },
                new PowerDomain { Id = 5, Superpower = "Telecinese", Description = "Mover objetos com o poder da mente." },
                new PowerDomain { Id = 6, Superpower = "Velocidade Sobrehumana", Description = "Capacidade de se mover em velocidades incríveis." },
                new PowerDomain { Id = 7, Superpower = "Regeneração", Description = "Capacidade de curar ferimentos rapidamente." },
                new PowerDomain { Id = 8, Superpower = "Controle do Fogo", Description = "Manipular e gerar fogo com as mãos." },
                new PowerDomain { Id = 9, Superpower = "Controle da Água", Description = "Manipular a água e criar formas com ela." },
                new PowerDomain { Id = 10, Superpower = "Campo de Força", Description = "Criar barreiras protetoras invisíveis." }
            );
        }

    }
}
