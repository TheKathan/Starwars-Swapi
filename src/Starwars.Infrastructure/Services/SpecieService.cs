namespace Starwars.Infrastructure.Services;

public class SpecieService : IStarwarsService<Specie>
{
    private readonly ILogger<SpecieService> _logger;
    private readonly SwapiClient _swapiClient;

    public SpecieService(ILogger<SpecieService> logger, SwapiClient swapiClient)
    {
        _logger = logger;
        _swapiClient = swapiClient;
    }

    public async Task<IEnumerable<Specie>> GetAll(bool wookiee = false)
    {
        _logger.LogInformation(">> GetAllSpecies");
        var result = await _swapiClient.GetAllSpecies(wookiee);
        _logger.LogInformation("<< GetAllSpecies");
        return result;
    }

    public async Task<Specie?> GetById(int id, bool wookiee = false)
    {
        _logger.LogInformation($">> GetSpecieById with id {id}");
        var result = await _swapiClient.GetSpecieById(id, wookiee);
        _logger.LogInformation("<< GetSpecieById");
        return result;
    }
}