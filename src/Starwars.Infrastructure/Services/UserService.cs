namespace Starwars.Infrastructure.Services;

public class UserService : IUserService
{
    private readonly ILogger<UserService> _logger;
    private readonly DataContext _context;
    private readonly IJwtService _jwtService;
    private readonly IMapper _mapper;

    public UserService(
        ILogger<UserService> logger,
        DataContext context,
        IJwtService jwtUtils, 
        IMapper mapper)
    {
        _logger = logger;
        _context = context;
        _jwtService = jwtUtils;
        _mapper = mapper;
    }

    public AuthenticateResponse? Authenticate(AuthenticateRequest model)
    {
        var user = _context.Users.SingleOrDefault(x => x.Username == model.Username);

        if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash) || user.Active)
            return null;
        
        var response = _mapper.Map<AuthenticateResponse>(user);
        response.Token = _jwtService.GenerateToken(user);
        
        user.LastLogin = DateTime.UtcNow;
        
        _context.Users.Update(user);
        _context.SaveChanges();
        return response;
    }

    public void Register(RegisterRequest model)
    {
        _logger.LogInformation(">> Register - {ModelEmail}", model.Email);
        
        if (_context.Users.Any(x => x.Username == model.Email))
            throw new AuthenticationException("Username '" + model.Email + "' is already taken");

        var user = _mapper.Map<User>(model);
        
        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);
        user.Created = DateTime.UtcNow;
        user.Updated = DateTime.UtcNow;
        
        _context.Users.Add(user);
        _context.SaveChanges();
        _logger.LogInformation($"<< Register");
    }

    public User GetById(Guid id)
    {
        var user = _context.Users.Find(id);
        if (user == null) throw new KeyNotFoundException("User not found");
        return user;
    }
}