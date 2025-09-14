using Dtos;
using Heroes.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Heroes.Controllers
{
    [ApiController]
    [Route("heroes")]
    public class HeroesController : ControllerBase
    {
        private readonly ICreateHeroeService _createHeroesService;
        private readonly IGetHeroeService _getHeroesService;
        private readonly IDeleteHeroeService _deleteHeroeService;
        private readonly IGetHeroeByIdService _getHeroeByIdService;

        public HeroesController(ICreateHeroeService createHeroesService, IGetHeroeService getHeroeService,
            IDeleteHeroeService deleteHeroeService, IGetHeroeByIdService getHeroeByIdService)
        {
            _createHeroesService = createHeroesService;
            _getHeroesService = getHeroeService;
            _deleteHeroeService = deleteHeroeService;
            _getHeroeByIdService = getHeroeByIdService;
        }

        [HttpPost]
        public async Task Create(CreateHeroDto heroe)
        {
           await _createHeroesService.Perform(heroe);
        }

        [HttpGet]
        public async Task<IEnumerable<GetHeroesDto>> GetHeroes()
        {
            return await _getHeroesService.Perform();
        }


        [HttpDelete]
        public async Task Delete(int id)
        {
            await _deleteHeroeService.Perform(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHeroeById(int id)
        {
            var heroe = await _getHeroeByIdService.Perform(id);

            if(heroe == null)
            {
                return NotFound();
            }

            return Ok(heroe);
        }

    }
}
