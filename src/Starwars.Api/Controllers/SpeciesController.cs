using Starwars.Swapi.Domain.Models;

namespace Starwars.Api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class SpeciesController : ControllerBase
{
    private readonly IStarwarsService<Specie> _starwarsService;

    public SpeciesController(IStarwarsService<Specie> starwarsService)
    {
        _starwarsService = starwarsService;
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAll(bool wookiee)
    {
        var result = await _starwarsService.GetAll(wookiee);
        if (!result.Any()) return BadRequest();
        return Ok(result);
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id, bool wookiee = false)
    {
        var result = await _starwarsService.GetById(id, wookiee);
        if (result == null) return BadRequest();
        return Ok(result);
    }
}