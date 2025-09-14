using Domain;
using Dtos;

namespace Services.Interfaces
{
    public interface IGetHeroeService
    {
        Task<IEnumerable<GetHeroesDto>> Perform();
    }
}