namespace Starwars.Swapi.Tests.Infrastructure;

[TestFixture]
public class MappingServiceTests
{
    private Mock<IApiService> _apiServiceMock;
    private MappingService _mappingService;

    [SetUp]
    public void Setup()
    {
        _apiServiceMock = new Mock<IApiService>();
        _mappingService = new MappingService(_apiServiceMock.Object);
    }

    [Test]
    public async Task MapFilm_ShouldMapFilmDtoToFilm()
    {
        // Arrange
        var limit = 1;
        var wookiee = false;
        var filmDto = new FilmDto
        {
            EpisodeId = 1,
            Url = "https://swapi.dev/api/films/1"
        };

        _apiServiceMock.Setup(a => a.GetByIdAsync<FilmDto>(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<bool>()))
            .ReturnsAsync(filmDto);

        // Act
        var result = await _mappingService.MapFilm(filmDto, limit, wookiee);

        // Assert
        Assert.NotNull(result);
        Assert.That(result.Id, Is.EqualTo(filmDto.Id));
        Assert.That(result.EpisodeId, Is.EqualTo(filmDto.EpisodeId));
    }

    [Test]
    public async Task MapPerson_ShouldMapPersonDtoToPerson()
    {
        // Arrange
        var limit = 1;
        var wookiee = false;
        var personDto = new PersonDto
        {
            Name = "Test Person",
            Url = "https://swapi.dev/api/people/1"
        };

        _apiServiceMock.Setup(a => a.GetByIdAsync<PersonDto>(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<bool>()))
            .ReturnsAsync(personDto);

        // Act
        var result = await _mappingService.MapPerson(personDto, limit, wookiee);

        // Assert
        Assert.NotNull(result);
        Assert.That(result.Id, Is.EqualTo(personDto.Id));
        Assert.That(result.Name, Is.EqualTo(personDto.Name));
    }

    [Test]
    public async Task MapPlanet_ShouldMapPlanetDtoToPlanet()
    {
        // Arrange
        var limit = 1;
        var wookiee = false;
        var planetDto = new PlanetDto
        {
            Name = "Test Planet",
            Url = "https://swapi.dev/api/planets/1"
        };

        _apiServiceMock.Setup(a => a.GetByIdAsync<PlanetDto>(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<bool>()))
            .ReturnsAsync(planetDto);

        // Act
        var result = await _mappingService.MapPlanet(planetDto, limit, wookiee);

        // Assert
        Assert.NotNull(result);
        Assert.That(result.Id, Is.EqualTo(planetDto.Id));
        Assert.That(result.Name, Is.EqualTo(planetDto.Name));
    }

    [Test]
    public async Task MapSpecie_ShouldMapSpecieDtoToSpecie()
    {
        // Arrange
        var limit = 1;
        var wookiee = false;
        var specieDto = new SpecieDto
        {
            Name = "Test Species",
            Url = "https://swapi.dev/api/species/1"
        };

        _apiServiceMock.Setup(a => a.GetByIdAsync<SpecieDto>(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<bool>()))
            .ReturnsAsync(specieDto);

        // Act
        var result = await _mappingService.MapSpecie(specieDto, limit, wookiee);

        // Assert
        Assert.NotNull(result);
        Assert.That(result.Id, Is.EqualTo(specieDto.Id));
        Assert.That(result.Name, Is.EqualTo(specieDto.Name));
    }

    [Test]
    public async Task MapStarship_ShouldMapStarshipDtoToStarship()
    {
        // Arrange
        var limit = 10;
        var wookiee = false;
        var starshipDto = new StarshipDto
        {
            Name = "Test Starship",
            Url = "https://swapi.dev/api/starships/1"
        };

        _apiServiceMock.Setup(a => a.GetByIdAsync<StarshipDto>(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<bool>()))
            .ReturnsAsync(starshipDto);

        // Act
        var result = await _mappingService.MapStarship(starshipDto, limit, wookiee);

        // Assert
        Assert.NotNull(result);
        Assert.That(result.Id, Is.EqualTo(starshipDto.Id));
        Assert.That(result.Name, Is.EqualTo(starshipDto.Name));
    }

    [Test]
    public async Task MapVehicle_ShouldMapVehicleDtoToVehicle()
    {
        // Arrange
        var limit = 1;
        var wookiee = false;
        var vehicleDto = new VehicleDto
        {
            Name = "Test Vehicle",
            Url = "https://swapi.dev/api/vehicles/1"
        };

        _apiServiceMock.Setup(a => a.GetByIdAsync<VehicleDto>(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<bool>()))
            .ReturnsAsync(vehicleDto);

        // Act
        var result = await _mappingService.MapVehicle(vehicleDto, limit, wookiee);

        // Assert
        Assert.NotNull(result);
        Assert.That(result.Id, Is.EqualTo(vehicleDto.Id));
        Assert.That(result.Name, Is.EqualTo(vehicleDto.Name));
    }
}