namespace Starwars.Infrastructure.Services;

public class PlanetService : IStarwarsService<Planet>
{
    private readonly ILogger<PlanetService> _logger;
    private readonly SwapiClient _swapiClient;

    public PlanetService(ILogger<PlanetService> logger, SwapiClient swapiClient)
    {
        _logger = logger;
        _swapiClient = swapiClient;
    }

    public async Task<IEnumerable<Planet>> GetAll(bool wookiee = false)
    {
        _logger.LogInformation(">> GetAllPlanets");
        var result = await _swapiClient.GetAllPlanets(wookiee);
        _logger.LogInformation("<< GetAllPlanets");
        return result;
    }

    public async Task<Planet?> GetById(int id, bool wookiee = false)
    {
        _logger.LogInformation($">> GetPlanetById with id {id}");
        var result = await _swapiClient.GetPlanetById(id, wookiee);
        _logger.LogInformation("<< GetPlanetById");
        return result;
    }
}