using Starwars.Swapi.Domain.Models.Entities;
using Starwars.Swapi.Domain.Models.Responses;
using Starwars.Swapi.Domain.Services;

namespace Starwars.Swapi.Infrastructure.Services;

public class ApiService : IApiService
{
    private readonly ILogger<ApiService> _logger;
    private readonly IRestService _restService;
    private readonly ICacheService _cacheService;

    public ApiService(ILogger<ApiService> logger, IRestService restService, ICacheService cacheService)
    {
        _logger = logger;
        _restService = restService;
        _cacheService = cacheService;
    }

    public async Task<IEnumerable<T>> GetAllAsync<T>(string uri, bool wookiee)
    {
        _logger.LogInformation(">> GetAllAsync");
        
        var cachedItems = _cacheService.GetItemsInCache<T>(wookiee);

        var result = cachedItems.ToList();
        if (!result.Any())
        {
            var paginatedResponse = await _restService.GetAsync<PaginatedResponse<T>>(uri, wookiee);
            
            if (paginatedResponse?.Results != null) result.AddRange(paginatedResponse.Results);
            
            var page = 2;
            while (paginatedResponse?.Next != null)
            {
                var nextPageResult = await _restService.GetAsync<PaginatedResponse<T>>(uri + "?page=" + page, wookiee);
                if (nextPageResult == null) break;
                if (nextPageResult.Results != null) result.AddRange(nextPageResult.Results);
                page++;
            }
            _cacheService.SetItemsInCache(result, wookiee);
        }
        
        _logger.LogInformation("<< GetAllAsync");
        return result;
    }

    public async Task<T?> GetByIdAsync<T>(string uri, int id, bool wookiee) where T : IRepositoryModel
    {
        _logger.LogInformation(">> GetByIdAsync");

        var result = _cacheService.GetItemInCache<T>(id, wookiee);

        if (result == null)
        {
            result = await _restService.GetAsync<T>($"{uri}/{id}", wookiee);
            if (result != null) _cacheService.SetItemInCache(result, wookiee);
        }
        
        _logger.LogInformation("<< GetByIdAsync");
        return result;
    }
}