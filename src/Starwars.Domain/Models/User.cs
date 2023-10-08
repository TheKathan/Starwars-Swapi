namespace Starwars.Domain.Models;

public class User
{
	public Guid Id { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string Username { get; set; }
	
	[JsonIgnore]
	public string PasswordHash { get; set; }
	public string Email { get; set; }
	public DateTime Created { get; set; }
	public DateTime? Updated { get; set; }
	public DateTime? LastLogin { get; set; }
	public bool Active { get; set; }
}