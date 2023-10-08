namespace Starwars.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
	private readonly IUserService _userService;

	public UserController(IUserService userService)
	{
		_userService = userService;
	}

	[AllowAnonymous]
	[HttpPost("authenticate")]
	public IActionResult Authenticate(AuthenticateRequest model)
	{
		var result = _userService.Authenticate(model);
		if (result == null) return Unauthorized(new { message = "Username or password is incorrect" });
		return Ok(result);
	}

	[AllowAnonymous]
	[HttpPost("register")]
	public IActionResult Register(RegisterRequest model)
	{
		if (!ModelState.IsValid)
		{
			return BadRequest(ModelState);
		}
		_userService.Register(model);
		return Ok(new { message = "Registration successful" });
	}

	[HttpGet("{id}")]
	public IActionResult GetById(Guid id)
	{
		var user = _userService.GetById(id);
		return Ok(user);
	}
}