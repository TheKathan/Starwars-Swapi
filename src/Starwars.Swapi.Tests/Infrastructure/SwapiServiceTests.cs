namespace Starwars.Swapi.Tests.Infrastructure;

[TestFixture]
public class SwapiServiceTests
{
    private Mock<ILogger<SwapiService>> _loggerMock;
    private Mock<IApiService> _apiServiceMock;
    private Mock<IMappingService> _mappingServiceMock;
    private SwapiService _swapiService;

    [SetUp]
    public void Setup()
    {
        _loggerMock = new Mock<ILogger<SwapiService>>();
        _apiServiceMock = new Mock<IApiService>();
        _mappingServiceMock = new Mock<IMappingService>();
        _swapiService = new SwapiService(_loggerMock.Object, _apiServiceMock.Object, _mappingServiceMock.Object);
    }

    [Test]
    public async Task GetAllFilms_ShouldReturnListOfFilms()
    {
        // Arrange
        var limit = 10;
        var wookiee = false;
        var filmDtos = new List<FilmDto> { new FilmDto(){EpisodeId = 1} };
        var mappedFilms = new List<Film> { new Film(){EpisodeId = 1} };

        _apiServiceMock.Setup(x => x.GetAllAsync<FilmDto>(Constants.Api.Resources.Films, wookiee))
            .ReturnsAsync(filmDtos);

        _mappingServiceMock.Setup(x => x.MapFilm(It.IsAny<FilmDto>(), limit, wookiee))!
            .ReturnsAsync((FilmDto dto, int l, bool w) => mappedFilms.FirstOrDefault());

        // Act
        var result = await _swapiService.GetAllFilms(limit, wookiee);

        // Assert
        Assert.IsNotNull(result);
        Assert.That(mappedFilms.Count, Is.EqualTo(result.Count()));
    }

    [Test]
    public async Task GetFilmById_WithInvalidId_ShouldReturnNull()
    {
        // Arrange
        var id = 123;
        var limit = 10;
        var wookiee = false;

        _apiServiceMock.Setup(x => x.GetByIdAsync<FilmDto>(Constants.Api.Resources.Films, id, wookiee))
            .ReturnsAsync((FilmDto)null!);

        // Act
        var result = await _swapiService.GetFilmById(id, limit, wookiee);

        // Assert
        Assert.That(result, Is.Null);
    }
}