namespace Starwars.Swapi.Domain.Models;

public class Cache<T>
{
    public DateTime Date { get; set; }
    public IEnumerable<T>? Items { get; set; }
}