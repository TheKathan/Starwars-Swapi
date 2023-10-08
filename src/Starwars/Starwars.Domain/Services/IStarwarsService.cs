namespace Starwars.Domain.Services;

public interface IStarwarsService<T>
{
    Task<IEnumerable<T>> GetAll(bool wookiee = false);
    Task<T?> GetById(int id, bool wookiee = false);
}