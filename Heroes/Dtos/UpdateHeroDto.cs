namespace Dtos
{
    public class UpdateHeroDto
    {
        public required string Name { get; set; }

        public required string Description { get; set; }

        public required int Height { get; set; }

        public required int Weight { get; set; }

        public DateTime? DateOfBirth { get; set; }
    }
} 