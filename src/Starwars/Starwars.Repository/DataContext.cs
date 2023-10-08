namespace Starwars.Repository;

public class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DataContext()
    {
        Database.EnsureCreated();
    }
    
    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source=database.db");
    }
    
    public DbSet<User> Users { get; set; }
}