namespace Starwars.Infrastructure.Services;

public class StarshipService : IStarwarsService<Starship>
{
    private readonly ILogger<StarshipService> _logger;
    private readonly SwapiClient _swapiClient;

    public StarshipService(ILogger<StarshipService> logger, SwapiClient swapiClient)
    {
        _logger = logger;
        _swapiClient = swapiClient;
    }

    public async Task<IEnumerable<Starship>> GetAll(bool wookiee = false)
    {
        _logger.LogInformation(">> GetAllStarships");
        var result = await _swapiClient.GetAllStarships(wookiee);
        _logger.LogInformation("<< GetAllStarships");
        return result;
    }

    public async Task<Starship?> GetById(int id, bool wookiee = false)
    {
        _logger.LogInformation($">> GetStarshipById with id {id}");
        var result = await _swapiClient.GetStarshipById(id, wookiee);
        _logger.LogInformation("<< GetStarshipById");
        return result;
    }
}