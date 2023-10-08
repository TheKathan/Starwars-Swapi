namespace Starwars.Swapi.Domain.Models;

public class Planet
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string RotationPeriod { get; set; }
    public string OrbitalPeriod { get; set; }
    public string Diameter { get; set; }
    public string Climate { get; set; }
    public string Gravity { get; set; }
    public string Terrain { get; set; }
    public string SurfaceWater { get; set; }
    public string Population { get; set; }
    public IEnumerable<Person> Residents { get; set; }
    public IEnumerable<Film> Films { get; set; }
    public string Created { get; set; }
    public string Edited { get; set; }
    public string Url { get; set; }
}
