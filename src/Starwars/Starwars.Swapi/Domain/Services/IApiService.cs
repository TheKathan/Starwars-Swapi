using Starwars.Swapi.Domain.Models.Entities;

namespace Starwars.Swapi.Domain.Services;

public interface IApiService
{
    Task<IEnumerable<T>> GetAllAsync<T>(string uri, bool wookiee);
    Task<T?> GetByIdAsync<T>(string uri, int id, bool wookiee) where T : IRepositoryModel;
}