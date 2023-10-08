using Starwars.Domain.Models;

namespace Starwars.Domain.Services;

public interface IJwtService
{
	public string GenerateToken(User user);
	public Guid? ValidateToken(string? token);
}