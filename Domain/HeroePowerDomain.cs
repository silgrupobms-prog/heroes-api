using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("hero_power")]
    public class HeroPowerDomain
    {
        [Column("heroe_id")]
        public int HeroeId { get; set; }

        public HeroeDomain Heroe { get; set; } = null!;

        [Column("power_id")]
        public int PowerId { get; set; }

        public PowerDomain Power { get; set; } = null!;
    }
}
