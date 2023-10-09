namespace Starwars.Swapi.Domain.Services;

public interface ISwapiService
{
    Task<IEnumerable<Film>> GetAllFilms(int limit, bool wookiee);
    Task<IEnumerable<Person>> GetAllPeople(int limit, bool wookiee);
    Task<IEnumerable<Planet>> GetAllPlanets(int limit, bool wookiee);
    Task<IEnumerable<Specie>> GetAllSpecies(int limit, bool wookiee);
    Task<IEnumerable<Starship>> GetAllStarships(int limit, bool wookiee);
    Task<IEnumerable<Vehicle>> GetAllVehicles(int limit, bool wookiee);
    Task<Film?> GetFilmById(int id, int limit, bool wookiee);
    Task<Person> GetPersonById(int id, int limit, bool wookiee);
    Task<Planet?> GetPlanetById(int id, int limit, bool wookiee);
    Task<Specie?> GetSpecieById(int id, int limit, bool wookiee);
    Task<Starship?> GetStarshipById(int id, int limit, bool wookiee);
    Task<Vehicle?> GetVehicleById(int id, int limit, bool wookiee);
}