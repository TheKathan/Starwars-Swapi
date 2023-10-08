namespace Starwars.Infrastructure.Services;

public class PersonService : IStarwarsService<Person>
{
    private readonly ILogger<PersonService> _logger;
    private readonly SwapiClient _swapiClient;

    public PersonService(ILogger<PersonService> logger, SwapiClient swapiClient)
    {
        _logger = logger;
        _swapiClient = swapiClient;
    }

    public async Task<IEnumerable<Person>> GetAll(bool wookiee = false)
    {
        _logger.LogInformation(">> GetAllPeople");
        var result = await _swapiClient.GetAllPeople(wookiee);
        _logger.LogInformation("<< GetAllPeople");
        return result;
    }

    public async Task<Person?> GetById(int id, bool wookiee = false)
    {
        _logger.LogInformation($">> GetPersonById with id {id}");
        var result = await _swapiClient.GetPersonById(id, wookiee);
        _logger.LogInformation("<< GetPersonById");
        return result;
    }
}