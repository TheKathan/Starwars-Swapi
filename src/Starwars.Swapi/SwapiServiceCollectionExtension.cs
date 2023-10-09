namespace Starwars.Swapi;

public static class SwapiServiceCollectionExtension
{
    public static IServiceCollection AddSwapi(this IServiceCollection services)
    {
        services.AddSqliteCache(options => {
            options.CachePath = $"{Environment.CurrentDirectory}/StarwarsCache.db";
        });
        
        services.AddScoped<SwapiClient>();
        
        services.AddTransient<ICacheService, CacheService>();
        services.AddScoped<IRestService, RestService>();
        services.AddScoped<IApiService, ApiService>();
        services.AddScoped<IMappingService, MappingService>();
        services.AddScoped<ISwapiService, SwapiService>();

        // Calculate the time to wait between calls to stay within the limit
        var throttleSleepTime = TimeSpan.FromMilliseconds(TimeSpan.FromDays(1).TotalMilliseconds / 10000);
        
        var policy = HttpPolicyExtensions
            .HandleTransientHttpError()
            .OrResult(response => (int)response.StatusCode == 429)
            .WaitAndRetryAsync(3, _ => throttleSleepTime);

        services.AddHttpClient<IRestService, RestService>("Swapi",
                client =>
                {
                    client.BaseAddress = new Uri(Constants.Api.Url);
                })
            .AddPolicyHandler(policy);
        return services;
    }
}