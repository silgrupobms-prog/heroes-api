using Domain;
using Dtos;
using Heroes.Dtos;

namespace Heroes.Interfaces
{
    public interface ICreateHeroesService
    {
        public Task Create(CreateHeroDto heroe);
       
    }
}
