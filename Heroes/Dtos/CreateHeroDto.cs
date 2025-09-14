namespace Dtos
{
    public class CreateHeroDto
    {
        public required string Name { get; set; }

        public required string Description { get; set; }

        public required int Height { get; set; }

        public required int Weight { get; set; }

        public DateTime? DateOfBirth { get; set; }


    }
}