using Domain;
using Dtos;

namespace Services.Interfaces
{
    public interface ICreateHeroeService
    {
        Task Perform(CreateHeroDto hero);
    }
}