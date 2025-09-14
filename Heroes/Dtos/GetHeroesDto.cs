namespace Dtos
{
    public class GetHeroesDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public required int Height { get; set; }
        public required int Weight { get; set; }


    }
}