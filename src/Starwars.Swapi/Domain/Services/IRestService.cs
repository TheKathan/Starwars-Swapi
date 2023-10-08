namespace Starwars.Swapi.Domain.Services;

public interface IRestService
{
    Task<T?> GetAsync<T>(string uri, bool wookie);
}

