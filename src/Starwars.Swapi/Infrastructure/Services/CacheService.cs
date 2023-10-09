namespace Starwars.Swapi.Infrastructure.Services
{
    public class CacheService : ICacheService
    {
        private readonly ILogger<CacheService> _logger;
        private readonly IDistributedCache _cache;

        public CacheService(ILogger<CacheService> logger, IDistributedCache memoryCache)
        {
            _logger = logger;
            _cache = memoryCache;
        }

        public IEnumerable<T> GetItemsInCache<T>(bool wookiee)
        {
            _logger.LogInformation($">> GetItemsInCache of type {typeof(T)}");

            var result = new List<T>();

            var key = $"{Constants.Cache.KeyEntry}-{typeof(T)}-{wookiee}";
            
            var cacheEntry = _cache.GetString(key);

            if (cacheEntry != null)
            {
                var items = JsonSerializer.Deserialize<Cache<T>>(cacheEntry)?.Items;
                if (items != null)
                    result = items.ToList();
            }

            _logger.LogInformation("<< GetItemsInCache");
            return result;
        }
        
        public void SetItemsInCache<T>(IEnumerable<T> list, bool wookiee)
        {
            _logger.LogInformation($">> SetItemsInCache of type {typeof(T)}");

            var key = $"{Constants.Cache.KeyEntry}-{typeof(T)}-{wookiee}";
            
            var cacheEntry = _cache.GetString(key);

            if (cacheEntry == null)
            {
                var cacheValue = new Cache<T>
                {
                    Date = DateTime.Now,
                    Items = list
                };
                
                cacheEntry = JsonSerializer.Serialize(cacheValue);

                _cache.SetString(key, cacheEntry);
            }
            
            _logger.LogInformation("<< SetItemsInCache");
        }
        
        public T? GetItemInCache<T>(int id, bool wookiee)
        {
            _logger.LogInformation($">> GetItemInCache of type {typeof(T)} with id {id}");
            
            var key = $"{Constants.Cache.KeyEntry}-{typeof(T)}-{id}-{wookiee}";

            var cacheEntry = _cache.GetString(key);

            if (cacheEntry != null)
            {
                var cacheItem = JsonSerializer.Deserialize<CacheItem<T>>(cacheEntry);
                if (cacheItem != null) return cacheItem.Item;
            }

            _logger.LogInformation("<< GetItemInCache");
            return default;
        }

        public void SetItemInCache<T>(T item, bool wookiee) where T : IRepositoryModel
        {
            _logger.LogInformation($">> SetItemInCache of type {typeof(T)} with id {item.Id}");
            
            var key = $"{Constants.Cache.KeyEntry}-{typeof(T)}-{item.Id}-{wookiee}";

            var cacheEntry = _cache.GetString(key);

            if (cacheEntry == null)
            {
                var cacheValue = new CacheItem<T>
                {
                    Date = DateTime.Now,
                    Item = item
                };
                
                cacheEntry = JsonSerializer.Serialize(cacheValue);

                _cache.SetString(key, cacheEntry);
            }
            
            _logger.LogInformation("<< SetItemInCache");
        }
    }
}
