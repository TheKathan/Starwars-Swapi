using Starwars.Swapi.Domain;
using Starwars.Swapi.Domain.Models;
using Starwars.Swapi.Domain.Models.Entities;
using Starwars.Swapi.Domain.Services;

namespace Starwars.Swapi.Infrastructure.Services;

public class SwapiService : ISwapiService
{
    private readonly ILogger<SwapiService> _logger;
    private readonly IApiService _apiService;
    private readonly IMappingService _mappingService;

    public SwapiService(ILogger<SwapiService> logger, IApiService apiService, IMappingService mappingService)
    {
        _logger = logger;
        _apiService = apiService;
        _mappingService = mappingService;
    }

    public async Task<IEnumerable<Film>> GetAllFilms(int limit, bool wookiee)
    {
        _logger.LogInformation(">> GetAllFilms");

        var dtoList = await _apiService.GetAllAsync<FilmDto>(Constants.Api.Resources.Films, wookiee);
        var tasks = dtoList.Select(async s => await _mappingService.MapFilm(s, limit, wookiee));
        var result = await Task.WhenAll(tasks);
        
        _logger.LogInformation("<< GetAllFilms");
        return result;
    }
    
    public async Task<IEnumerable<Person>> GetAllPeople(int limit, bool wookiee)
    {
        _logger.LogInformation(">> GetAllPeople");

        var dtoList = await _apiService.GetAllAsync<PersonDto>(Constants.Api.Resources.People, wookiee);
        var tasks = dtoList.Select(async s => await _mappingService.MapPerson(s, limit, wookiee));
        var result = await Task.WhenAll(tasks);
        
        _logger.LogInformation("<< GetAllPeople");
        return result;
    }
    
    public async Task<IEnumerable<Planet>> GetAllPlanets(int limit, bool wookiee)
    {
        _logger.LogInformation(">> GetAllPlanets");

        var dtoList = await _apiService.GetAllAsync<PlanetDto>(Constants.Api.Resources.Planets, wookiee);
        var tasks = dtoList.Select(async s => await _mappingService.MapPlanet(s, limit, wookiee));
        var result = await Task.WhenAll(tasks);
        
        _logger.LogInformation("<< GetAllPlanets");
        return result;
    }
    
    public async Task<IEnumerable<Specie>> GetAllSpecies(int limit, bool wookiee)
    {
        _logger.LogInformation(">> GetAllSpecies");

        var dtoList = await _apiService.GetAllAsync<SpecieDto>(Constants.Api.Resources.Species, wookiee);
        var tasks = dtoList.Select(async s => await _mappingService.MapSpecie(s, limit, wookiee));
        var result = await Task.WhenAll(tasks);
        
        _logger.LogInformation("<< GetAllSpecies");
        return result;
    }
    
    public async Task<IEnumerable<Starship>> GetAllStarships(int limit, bool wookiee)
    {
        _logger.LogInformation(">> GetAllStarships");

        var dtoList = await _apiService.GetAllAsync<StarshipDto>(Constants.Api.Resources.Starships, wookiee);
        var tasks = dtoList.Select(async s => await _mappingService.MapStarship(s, limit, wookiee));
        var result = await Task.WhenAll(tasks);
        
        _logger.LogInformation("<< GetAllStarships");
        return result;
    }
    
    public async Task<IEnumerable<Vehicle>> GetAllVehicles(int limit, bool wookiee)
    {
        _logger.LogInformation(">> GetAllVehicles");

        var dtoList = await _apiService.GetAllAsync<VehicleDto>(Constants.Api.Resources.Vehicles, wookiee);
        var tasks = dtoList.Select(async s => await _mappingService.MapVehicle(s, limit, wookiee));
        var result = await Task.WhenAll(tasks);
        
        _logger.LogInformation("<< GetAllVehicles");
        return result;
    }
    
    public async Task<Film?> GetFilmById(int id, int limit, bool wookiee)
    {
        _logger.LogInformation(">> GetFilmById");

        var dto = await _apiService.GetByIdAsync<FilmDto>(Constants.Api.Resources.Films, id, wookiee);

        if (dto == null) return null;
        var result = await _mappingService.MapFilm(dto, limit, wookiee);

        _logger.LogInformation("<< GetFilmById");
        return result;
    }
    
    public async Task<Person> GetPersonById(int id, int limit, bool wookiee)
    {
        _logger.LogInformation(">> GetPersonById");

        var dto = await _apiService.GetByIdAsync<PersonDto>(Constants.Api.Resources.People, id, wookiee);
        
        if (dto == null) return null;
        var result = await _mappingService.MapPerson(dto, limit, wookiee);
        
        _logger.LogInformation("<< GetPersonById");
        return result;
    }
    
    public async Task<Planet?> GetPlanetById(int id, int limit, bool wookiee)
    {
        _logger.LogInformation(">> GetPlanetById");

        var dto = await _apiService.GetByIdAsync<PlanetDto>(Constants.Api.Resources.Planets, id, wookiee);
        
        if (dto == null) return null;
        var result = await _mappingService.MapPlanet(dto, limit, wookiee);
        
        _logger.LogInformation("<< GetPlanetById");
        return result;
    }
    
    public async Task<Specie?> GetSpecieById(int id, int limit, bool wookiee)
    {
        _logger.LogInformation(">> GetSpecieById");

        var dto = await _apiService.GetByIdAsync<SpecieDto>(Constants.Api.Resources.Species, id, wookiee);
        
        if (dto == null) return null;
        var result = await _mappingService.MapSpecie(dto, limit, wookiee);
        
        _logger.LogInformation("<< GetSpecieById");
        return result;
    }
    
    public async Task<Starship?> GetStarshipById(int id, int limit, bool wookiee)
    {
        _logger.LogInformation(">> GetStarshipById");

        var dto = await _apiService.GetByIdAsync<StarshipDto>(Constants.Api.Resources.Starships, id, wookiee);
        
        if (dto == null) return null;
        var result = await _mappingService.MapStarship(dto, limit, wookiee);
        
        _logger.LogInformation("<< GetStarshipById");
        return result;
    }
    
    public async Task<Vehicle?> GetVehicleById(int id, int limit, bool wookiee)
    {
        _logger.LogInformation(">> GetVehicleById");

        var dto = await _apiService.GetByIdAsync<VehicleDto>(Constants.Api.Resources.Vehicles, id, wookiee);
        
        if (dto == null) return null;
        var result = await _mappingService.MapVehicle(dto, limit, wookiee);
        
        _logger.LogInformation("<< GetVehicleById");
        return result;
    }
}