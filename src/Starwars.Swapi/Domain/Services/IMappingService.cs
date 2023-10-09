namespace Starwars.Swapi.Domain.Services;

public interface IMappingService
{
    Task<Film> MapFilm(FilmDto input, int limit, bool wookiee);
    Task<Person> MapPerson(PersonDto input, int limit, bool wookiee);
    Task<Planet?> MapPlanet(PlanetDto input, int limit, bool wookiee);
    Task<Starship> MapStarship(StarshipDto input, int limit, bool wookiee);
    Task<Specie> MapSpecie(SpecieDto input, int limit, bool wookiee);
    Task<Vehicle> MapVehicle(VehicleDto input, int limit, bool wookiee);
}