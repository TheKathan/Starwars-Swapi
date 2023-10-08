namespace Starwars.Domain.Models;

public class CacheItem<T>
{
    public DateTime Date { get; set; }
    public T Item { get; set; }
}