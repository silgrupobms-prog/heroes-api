using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("powers")]
    public class PowerDomain
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public required string Superpower { get; set; }

        [StringLength(250)]
        public string? Description { get; set; }

        public ICollection<HeroPowerDomain> HeroPowers { get; set; } = new List<HeroPowerDomain>();
    }
}
