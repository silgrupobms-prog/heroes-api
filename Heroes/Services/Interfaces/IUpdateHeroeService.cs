using Dtos;

namespace Services.Interfaces
{
    public interface IUpdateHeroeService
    {
        Task Perform(int id, UpdateHeroDto hero);
    }
} 