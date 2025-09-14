using Dtos;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Heroes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HeroPowerController : ControllerBase
    {
        private readonly IHeroPowerService _heroPowerService;

        public HeroPowerController(IHeroPowerService heroPowerService)
        {
            _heroPowerService = heroPowerService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateHeroPowerDto dto)
        {
            var entity = new HeroPowerDomain
            {
                HeroeId = dto.HeroId,
                PowerId = dto.PowerId
            };

            await _heroPowerService.AddAsync(entity);
            return Ok();
        }

        [HttpGet("{heroId}")]
        public async Task<IActionResult> GetByHeroIdAsync(int heroId)
        {
            var result = await _heroPowerService.GetByHeroIdAsync(heroId);

            var dto = result.Select(x => new HeroPowerDto
            {
                HeroName = x.Heroe?.Name,
                PowerId = x.PowerId,
                PowerName = x.Power?.Superpower,
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