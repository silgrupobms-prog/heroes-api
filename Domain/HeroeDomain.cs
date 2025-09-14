using System.Collections.Generic;

namespace Domain
{
    public class HeroeDomain
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public required string Description { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public int Weight { get; set; }
        public int Height { get; set; }

        public ICollection<HeroPowerDomain>? HeroePowers { get; set; }
    }
}