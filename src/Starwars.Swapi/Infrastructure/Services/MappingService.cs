using Starwars.Swapi.Domain;
using Starwars.Swapi.Domain.Models;
using Starwars.Swapi.Domain.Models.Entities;
using Starwars.Swapi.Domain.Services;
using Starwars.Swapi.Domain.Utils;

namespace Starwars.Swapi.Infrastructure.Services;

public class MappingService : IMappingService
{
    private readonly IApiService _apiService;

    public MappingService(IApiService apiService)
    {
        _apiService = apiService;
    }

    public async Task<Film> MapFilm(FilmDto input, int limit, bool wookiee)
    {
        limit--;
        
        var result = new Film
        {
            Id = RegexUtils.GetIdFromUrl(input.Url),
            EpisodeId = Convert.ToInt32(input.EpisodeId),
            Title = input.Title,
            OpeningCrawl = input.OpeningCrawl,
            Director = input.Director,
            Producer = input.Producer,
            ReleaseDate = input.ReleaseDate,
            Characters = await GetPeopleFromUrl(input.Characters, limit, wookiee),
            Planets = await GetPlanetsFromUrl(input.Planets, limit, wookiee),
            Starships = await GetStarshipsFromUrl(input.Starships, limit, wookiee),
            Vehicles = await GetVehiclesFromUrl(input.Vehicles, limit, wookiee),
            Species = await GetSpeciesFromUrl(input.Species, limit, wookiee),
            Created = input.Created,
            Edited = input.Edited,
            Url = input.Url
        };
        return result;
    }

    public async Task<Person> MapPerson(PersonDto input, int limit, bool wookiee)
    {
        limit--;
        
        var result = new Person
        {
            Id = RegexUtils.GetIdFromUrl(input.Url),
            Name = input.Name,
            Height = input.Height,
            Mass = input.Mass,
            HairColor = input.HairColor,
            SkinColor = input.SkinColor,
            EyeColor = input.EyeColor,
            BirthYear = input.BirthYear,
            Gender = input.Gender,
            Homeworld = await GetPlanetFromUrl(input.Homeworld, limit, wookiee),
            Films = await GetFilmsFromUrl(input.Films, limit, wookiee),
            Species = await GetSpeciesFromUrl(input.Species, limit, wookiee),
            Vehicles = await GetVehiclesFromUrl(input.Vehicles, limit, wookiee),
            Starships = await GetStarshipsFromUrl(input.Starships, limit, wookiee),
            Created = input.Created,
            Edited = input.Created,
            Url = input.Url
        };

        return result;
    }

    public async Task<Planet?> MapPlanet(PlanetDto input, int limit, bool wookiee)
    {
        limit--;

        var result = new Planet
        {
            Id = RegexUtils.GetIdFromUrl(input.Url),
            Name = input.Name,
            RotationPeriod = input.RotationPeriod,
            OrbitalPeriod = input.OrbitalPeriod,
            Diameter = input.Diameter,
            Climate = input.Climate,
            Gravity = input.Gravity,
            Terrain = input.Terrain,
            SurfaceWater = input.SurfaceWater,
            Population = input.Population,
            Residents = await GetPeopleFromUrl(input.Residents, limit, wookiee),
            Films = await GetFilmsFromUrl(input.Films, limit, wookiee),
            Created = input.Created,
            Edited = input.Edited,
            Url = input.Url
        };

        return result;
    }

    public async Task<Starship> MapStarship(StarshipDto input, int limit, bool wookiee)
    {
        limit--;

        var result = new Starship
        {
            Id = RegexUtils.GetIdFromUrl(input.Url),
            Name = input.Name,
            Model = input.Model,
            Manufacturer = input.Manufacturer,
            CostInCredits = input.CostInCredits,
            Length = input.Length,
            MaxAtmospheringSpeed = input.MaxAtmospheringSpeed,
            Crew = input.Crew,
            Passengers = input.Passengers,
            CargoCapacity = input.CargoCapacity,
            Consumables = input.Consumables,
            HyperdriveRating = input.HyperdriveRating,
            Mglt = input.Mglt,
            StarshipClass = input.StarshipClass,
            Pilots = await GetPeopleFromUrl(input.Pilots, limit, wookiee),
            Films = await GetFilmsFromUrl(input.Films, limit, wookiee),
            Created = input.Created,
            Edited = input.Edited,
            Url = input.Url
        };

        return result;
    }

    public async Task<Specie> MapSpecie(SpecieDto input, int limit, bool wookiee)
    {
        limit--;

        var result = new Specie
        {
            Id = RegexUtils.GetIdFromUrl(input.Url),
            Name = input.Name,
            Classification = input.Classification,
            Designation = input.Designation,
            AverageHeight = input.AverageHeight,
            SkinColors = input.SkinColors,
            HairColors = input.HairColors,
            EyeColors = input.EyeColors,
            AverageLifespan = input.AverageLifespan,
            Homeworld = await GetPlanetFromUrl(input.Homeworld, limit, wookiee),
            Language = input.Language,
            People = await GetPeopleFromUrl(input.People, limit, wookiee),
            Films = await GetFilmsFromUrl(input.Films, limit, wookiee),
            Created = input.Created,
            Edited = input.Edited,
            Url = input.Url
        };

        return result;
    }

    public async Task<Vehicle> MapVehicle(VehicleDto input, int limit, bool wookiee)
    {
        limit--;

        var result = new Vehicle
        {
            Id = RegexUtils.GetIdFromUrl(input.Url),
            Name = input.Name,
            Model = input.Model,
            Manufacturer = input.Manufacturer,
            CostInCredits = input.CostInCredits,
            Length = input.Length,
            MaxAtmospheringSpeed = input.MaxAtmospheringSpeed,
            Crew = input.Crew,
            Passengers = input.Passengers,
            CargoCapacity = input.CargoCapacity,
            Consumables = input.Consumables,
            VehicleClass = input.VehicleClass,
            Pilots = await GetPeopleFromUrl(input.Pilots, limit, wookiee),
            Films = await GetFilmsFromUrl(input.Films, limit, wookiee),
            Created = input.Created,
            Edited = input.Edited,
            Url = input.Url
        };

        return result;
    }

    private async Task<IEnumerable<Film>> GetFilmsFromUrl(IEnumerable<string>? urls, int limit, bool wookiee)
    {
        var result = new List<Film>();
        
        if (urls == null || limit <= 0) return result;
        foreach (var url in urls)
        {
            var id = RegexUtils.GetIdFromUrl(url);
            var dto = await _apiService.GetByIdAsync<FilmDto>(Constants.Api.Resources.Films, id, wookiee);
            if (dto == null) continue;
            var item = await MapFilm(dto, limit, wookiee);
            result.Add(item);
        }

        return result;
    }

    private async Task<IEnumerable<Person>> GetPeopleFromUrl(IEnumerable<string>? urls, int limit, bool wookiee)
    {
        var result = new List<Person>();

        if (urls == null || limit <= 0) return result;
        foreach (var url in urls)
        {
            var id = RegexUtils.GetIdFromUrl(url);
            var dto = await _apiService.GetByIdAsync<PersonDto>(Constants.Api.Resources.People, id, wookiee);
            if (dto == null) continue;
            var item = await MapPerson(dto, limit, wookiee);
            result.Add(item);
        }

        return result;
    }

    private async Task<IEnumerable<Planet?>> GetPlanetsFromUrl(IEnumerable<string>? urls, int limit, bool wookiee)
    {
        var result = new List<Planet?>();
        
        if (urls == null || limit <= 0) return result;
        foreach (var url in urls)
        {
            var id = RegexUtils.GetIdFromUrl(url);
            var dto = await _apiService.GetByIdAsync<PlanetDto>(Constants.Api.Resources.Planets, id, wookiee);
            if (dto == null) continue;
            var item = await MapPlanet(dto, limit, wookiee);
            result.Add(item);
        }

        return result;
    }

    private async Task<IEnumerable<Starship>> GetStarshipsFromUrl(IEnumerable<string>? urls, int limit, bool wookiee)
    {
        var result = new List<Starship>();
        
        if (urls == null || limit <= 0) return result;
        foreach (var url in urls)
        {
            var id = RegexUtils.GetIdFromUrl(url);
            var dto = await _apiService.GetByIdAsync<StarshipDto>(Constants.Api.Resources.Starships, id, wookiee);
            if (dto == null) continue;
            var item = await MapStarship(dto, limit, wookiee);
            result.Add(item);
        }

        return result;
    }

    private async Task<IEnumerable<Specie>> GetSpeciesFromUrl(IEnumerable<string>? urls, int limit, bool wookiee)
    {
        var result = new List<Specie>();

        if (urls == null || limit <= 0) return result;
        foreach (var url in urls)
        {
            var id = RegexUtils.GetIdFromUrl(url);
            var dto = await _apiService.GetByIdAsync<SpecieDto>(Constants.Api.Resources.Species, id, wookiee);
            if (dto == null) continue;
            var item = await MapSpecie(dto, limit, wookiee);
            result.Add(item);
        }

        return result;
    }
    
    private async Task<IEnumerable<Vehicle>> GetVehiclesFromUrl(IEnumerable<string>? urls, int limit, bool wookiee)
    {
        var result = new List<Vehicle>();
        
        if (urls == null || limit <= 0) return result;
        foreach (var url in urls)
        {
            var id = RegexUtils.GetIdFromUrl(url);
            var dto = await _apiService.GetByIdAsync<VehicleDto>(Constants.Api.Resources.Vehicles, id, wookiee);
            if (dto == null) continue;
            var item = await MapVehicle(dto, limit, wookiee);
            result.Add(item);
        }

        return result;
    }

    private async Task<Planet?> GetPlanetFromUrl(string homeworld, int limit, bool wookiee)
    {
        if (string.IsNullOrEmpty(homeworld)) return null;
        var id = RegexUtils.GetIdFromUrl(homeworld);
        var dto = await _apiService.GetByIdAsync<PlanetDto>(Constants.Api.Resources.Planets, id, wookiee);
        if (dto == null) return null;
        return await MapPlanet(dto, limit, wookiee);
    }
}