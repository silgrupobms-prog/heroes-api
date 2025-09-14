using Domain;

namespace Services.Interfaces
{
    public interface IGetHeroeByIdService
    {
        Task<HeroeDomain> Perform(int id);
    }
}