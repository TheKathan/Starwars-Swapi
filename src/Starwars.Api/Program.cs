using Starwars.Swapi;
using Starwars.Swapi.Domain.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>();

builder.Services.AddSwapi();

builder.Services.AddCors();
builder.Services.AddControllers();

builder.Services.AddMemoryCache();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

builder.Services.AddTransient<DataContext>();
builder.Services.AddTransient<IJwtService, JwtService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IStarwarsService<Film>, FilmService>();
builder.Services.AddTransient<IStarwarsService<Person>, PersonService>();
builder.Services.AddTransient<IStarwarsService<Specie>, SpecieService>();
builder.Services.AddTransient<IStarwarsService<Planet>, PlanetService>();
builder.Services.AddTransient<IStarwarsService<Starship>, StarshipService>();
builder.Services.AddTransient<IStarwarsService<Vehicle>, VehicleService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<DataContext>();
    dataContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseMiddleware<JwtMiddleware>();

app.MapControllers();

app.Run();
