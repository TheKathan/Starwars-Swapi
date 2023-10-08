using Starwars.Domain.Models;
using Starwars.Domain.Models.Requests;
using Starwars.Domain.Models.Responses;

namespace Starwars.Domain.Services;

public interface IUserService
{
	AuthenticateResponse? Authenticate(AuthenticateRequest model);
	User GetById(Guid id);
	void Register(RegisterRequest model);
}