using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("heroes")]
    public class Hero
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<HeroPower> HeroPowers { get; set; }
    }
}