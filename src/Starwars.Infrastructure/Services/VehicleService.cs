namespace Starwars.Infrastructure.Services;

public class VehicleService : IStarwarsService<Vehicle>
{
    private readonly ILogger<VehicleService> _logger;
    private readonly SwapiClient _swapiClient;

    public VehicleService(SwapiClient swapiClient, ILogger<VehicleService> logger)
    {
        _swapiClient = swapiClient;
        _logger = logger;
    }

    public async Task<IEnumerable<Vehicle>> GetAll(bool wookiee = false)
    {
        _logger.LogInformation(">> GetAllVehicles");
        var result = await _swapiClient.GetAllVehicles(wookiee);
        _logger.LogInformation("<< GetAllVehicles");
        return result;
    }

    public async Task<Vehicle?> GetById(int id, bool wookiee = false)
    {
        _logger.LogInformation($">> GetVehicleById with id {id}");
        var result = await _swapiClient.GetVehicleById(id, wookiee);
        _logger.LogInformation("<< GetVehicleById");
        return result;
    }
}