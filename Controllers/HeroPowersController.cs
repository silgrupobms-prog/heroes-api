using Dtos;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Interfaces;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HeroPowersController : ControllerBase
    {
        private readonly IHeroPowerService _heroPowerService;

        public HeroPowersController(IHeroPowerService heroPowerService)
        {
            _heroPowerService = heroPowerService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] HeroPower entity)
        {
            await _heroPowerService.AddAsync(entity);
            return Ok();
        }

        [HttpGet("{heroId}")]
        public async Task<IActionResult> GetByHeroId(int heroId)
        {
            var result = await _heroPowerService.GetByHeroId(heroId);
            if (result == null || !result.Any())
                return NotFound();

            var dto = result.Select(x => new HeroPowerDto
            {
                HeroName = x.Hero.Name,
                PowerId = x.PowerId,
                PowerName = x.Power.Name
            }).ToList();

            return Ok(dto);
        }

        [HttpDelete("{heroId}/{powerId}")]
        public async Task<IActionResult> DeleteAsync(int heroId, int powerId)
        {
            await _heroPowerService.DeleteAsync(heroId, powerId);
            return NoContent();
        }
    }
}