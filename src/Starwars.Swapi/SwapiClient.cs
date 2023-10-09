namespace Starwars.Swapi;

public class SwapiClient
{
    private readonly ILogger<SwapiClient> _logger;
    private readonly ISwapiService _swapiService;
    
    public SwapiClient(ILogger<SwapiClient> logger, ISwapiService swapiService)
    {
        _logger = logger;
        _swapiService = swapiService;
    }

    public async Task<IEnumerable<Film>> GetAllFilms(bool wookiee = false, int limit = 2)
    {
        _logger.LogInformation("> GetAllFilms");

        var result = await _swapiService.GetAllFilms(limit, wookiee);
        
        _logger.LogInformation("< GetAllFilms");
        return result;
    }
    
    public async Task<IEnumerable<Person>> GetAllPeople(bool wookiee = false, int limit = 2)
    {
        _logger.LogInformation("> GetAllPeople");

        var result = await _swapiService.GetAllPeople(limit, wookiee);
        
        _logger.LogInformation("< GetAllPeople");
        return result;
    }
    
    public async Task<IEnumerable<Planet>> GetAllPlanets(bool wookiee = false, int limit = 2)
    {
        _logger.LogInformation("> GetAllPlanets");

        var result = await _swapiService.GetAllPlanets(limit, wookiee);
        
        _logger.LogInformation("< GetAllPlanets");
        return result;
    }
    
    public async Task<IEnumerable<Specie>> GetAllSpecies(bool wookiee = false, int limit = 2)
    {
        _logger.LogInformation("> GetAllSpecies");

        var result = await _swapiService.GetAllSpecies(limit, wookiee);
        
        _logger.LogInformation("< GetAllSpecies");
        return result;
    }
    
    public async Task<IEnumerable<Starship>> GetAllStarships(bool wookiee = false, int limit = 2)
    {
        _logger.LogInformation("> GetAllStarships");

        var result = await _swapiService.GetAllStarships(limit, wookiee);
        
        _logger.LogInformation("< GetAllStarships");
        return result;
    }
    
    public async Task<IEnumerable<Vehicle>> GetAllVehicles(bool wookiee = false, int limit = 2)
    {
        _logger.LogInformation("> GetAllVehicles");

        var result = await _swapiService.GetAllVehicles(limit, wookiee);
        
        _logger.LogInformation("< GetAllVehicles");
        return result;
    }
    
    public async Task<Film?> GetFilmById(int id, bool wookiee = false, int limit = 2)
    {
        _logger.LogInformation("> GetFilmById");

        var result = await _swapiService.GetFilmById(id, limit, wookiee);
        
        _logger.LogInformation("< GetFilmById");
        return result;
    }
    
    public async Task<Person> GetPersonById(int id, bool wookiee = false, int limit = 2)
    {
        _logger.LogInformation("> GetPersonById");

        var result = await _swapiService.GetPersonById(id, limit, wookiee);
        
        _logger.LogInformation("< GetPersonById");
        return result;
    }
    
    public async Task<Planet?> GetPlanetById(int id, bool wookiee = false, int limit = 2)
    {
        _logger.LogInformation("> GetPlanetById");

        var result = await _swapiService.GetPlanetById(id, limit, wookiee);
        
        _logger.LogInformation("< GetPlanetById");
        return result;
    }
    
    public async Task<Specie?> GetSpecieById(int id, bool wookiee = false, int limit = 2)
    {
        _logger.LogInformation("> GetSpecieById");

        var result = await _swapiService.GetSpecieById(id, limit, wookiee);
        
        _logger.LogInformation("< GetSpecieById");
        return result;
    }
    
    public async Task<Starship?> GetStarshipById(int id, bool wookiee = false, int limit = 2)
    {
        _logger.LogInformation("> GetStarshipById");

        var result = await _swapiService.GetStarshipById(id, limit, wookiee);
        
        _logger.LogInformation("< GetStarshipById");
        return result;
    }
    
    public async Task<Vehicle?> GetVehicleById(int id, bool wookiee = false, int limit = 2)
    {
        _logger.LogInformation("> GetVehicleById");

        var result = await _swapiService.GetVehicleById(id, limit, wookiee);
        
        _logger.LogInformation("< GetVehicleById");
        return result;
    }
}