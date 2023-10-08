namespace Starwars.Api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class VehiclesController : ControllerBase
{
    private readonly IStarwarsService<Vehicle> _starwarsService;

    public VehiclesController(IStarwarsService<Vehicle> starwarsService)
    {
        _starwarsService = starwarsService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(bool wookiee)
    {
        var result = await _starwarsService.GetAll(wookiee);
        if (!result.Any()) return BadRequest();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id, bool wookiee = false)
    {
        var result = await _starwarsService.GetById(id, wookiee);
        if (result == null) return BadRequest();
        return Ok(result);
    }
}