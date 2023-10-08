namespace Starwars.Swapi.Domain.Models;

public class Starship
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public string Manufacturer { get; set; }
    public string CostInCredits { get; set; }
    public string Length { get; set; }
    public string MaxAtmospheringSpeed { get; set; }
    public string Crew { get; set; }
    public string Passengers { get; set; }
    public string CargoCapacity { get; set; }
    public string Consumables { get; set; }
    public string HyperdriveRating { get; set; }
    public string Mglt { get; set; }
    public string StarshipClass { get; set; }
    public IEnumerable<Person> Pilots { get; set; }
    public IEnumerable<Film> Films { get; set; }
    public string Created { get; set; }
    public string Edited { get; set; }
    public string Url { get; set; }
}
