namespace Starwars.Infrastructure.Services;

public class FilmService : IStarwarsService<Film>
{
    private readonly ILogger<FilmService> _logger;
    private readonly SwapiClient _swapiClient;

    public FilmService(ILogger<FilmService> logger, SwapiClient swapiClient)
    {
        _logger = logger;
        _swapiClient = swapiClient;
    }

    public async Task<IEnumerable<Film>> GetAll(bool wookiee = false)
    {
        _logger.LogInformation(">> GetAllFilms");
        var result = await _swapiClient.GetAllFilms(wookiee, 1);
        _logger.LogInformation("<< GetAllFilms");
        return result;
    }

    public async Task<Film?> GetById(int id, bool wookiee = false)
    {
        _logger.LogInformation($">> GetFilmById with id {id}");
        var result = await _swapiClient.GetFilmById(id, wookiee);
        _logger.LogInformation("<< GetFilmById");
        return result;
    }
}