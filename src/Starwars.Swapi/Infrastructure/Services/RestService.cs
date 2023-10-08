using Starwars.Swapi.Domain.Services;
using Starwars.Swapi.Domain.Utils;

namespace Starwars.Swapi.Infrastructure.Services;

public class RestService : IRestService
{
	private readonly ILogger<RestService> _logger;
	private readonly HttpClient _httpClient;

	public RestService(ILogger<RestService> logger, HttpClient httpClient)
	{
		_logger = logger;
		_httpClient = httpClient;
	}

	public async Task<T?> GetAsync<T>(string uri, bool wookiee)
	{
		try
		{
			var url = wookiee ? !uri.Contains('?') ? uri + "?format=wookiee" : "&format=wookiee" : uri;
			using var response = await _httpClient.GetAsync($"{url}");

			var responseBody = await response.Content.ReadAsStringAsync();
			ValidationUtils.ResourceFoundRequest(response, responseBody);
			ValidationUtils.SuccessfulRequest(response, responseBody);

			var result = JsonSerializer.Deserialize<T>(responseBody);
			ValidationUtils.ResponseNotNull(result);

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogError("{Message} : {StackTrace}", ex.Message, ex.StackTrace);
			return default;
		}
	}
}