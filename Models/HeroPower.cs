using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("heroes_powers")]
    public class HeroPower
    {
        [Column("hero_id")]
        public int HeroId { get; set; }
        public Hero Hero { get; set; }

        [Column("power_id")]
        public int PowerId { get; set; }
        public Power Power { get; set; }
    }
}