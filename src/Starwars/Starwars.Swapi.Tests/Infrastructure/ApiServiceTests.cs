using Starwars.Swapi.Domain.Models.Responses;

namespace Starwars.Swapi.Tests.Infrastructure;

[TestFixture]
public class ApiServiceTests
{
    private Mock<ILogger<ApiService>> _loggerMock;
    private Mock<IRestService> _restServiceMock;
    private Mock<ICacheService> _cacheServiceMock;

    private ApiService _apiService;

    [SetUp]
    public void Setup()
    {
        _loggerMock = new Mock<ILogger<ApiService>>();
        _restServiceMock = new Mock<IRestService>();
        _cacheServiceMock = new Mock<ICacheService>();

        _apiService = new ApiService(_loggerMock.Object, _restServiceMock.Object, _cacheServiceMock.Object);
    }

    [Test]
    public async Task GetAllAsync_ShouldRetrieveCachedItems()
    {
        // Arrange
        var uri = "https://swapi.dev/api/films";
        var wookiee = false;
        var cachedItems = new List<FilmDto> { new FilmDto(){EpisodeId = 1}, new FilmDto(){EpisodeId = 2} };

        _cacheServiceMock.Setup(c => c.GetItemsInCache<FilmDto>(wookiee)).Returns(cachedItems);

        // Act
        var result = await _apiService.GetAllAsync<FilmDto>(uri, wookiee);

        // Assert
        Assert.NotNull(result);
        Assert.That(result.Count(), Is.EqualTo(cachedItems.Count));
    }

    [Test]
    public async Task GetAllAsync_ShouldRetrieveFromRestServiceAndCache()
    {
        // Arrange
        var uri = "https://swapi.dev/api/films";
        var wookiee = false;
        var paginatedResponse = new PaginatedResponse<Film>
        {
            Results = new List<Film> { new Film(){EpisodeId = 1} },
            Next = "https://swapi.dev/api/films?page=2"
        };

        _cacheServiceMock.Setup(c => c.GetItemsInCache<Film>(wookiee)).Returns(new List<Film>());

        _restServiceMock.Setup(r => r.GetAsync<PaginatedResponse<Film>>(uri, wookiee))
            .ReturnsAsync(paginatedResponse);

        // Act
        var result = await _apiService.GetAllAsync<Film>(uri, wookiee);

        // Assert
        Assert.NotNull(result);
        Assert.That(result.Count(), Is.EqualTo(1));
        _cacheServiceMock.Verify(c => c.SetItemsInCache(It.IsAny<IEnumerable<Film>>(), wookiee), Times.Once);
    }

    [Test]
    public async Task GetByIdAsync_ShouldRetrieveCachedItem()
    {
        // Arrange
        var uri = "https://swapi.dev/api/films";
        var id = 1;
        var wookiee = false;
        var cachedItem = new FilmDto { EpisodeId = 1 , Url = "https://swapi.dev/api/films/1"};

        _cacheServiceMock.Setup(c => c.GetItemInCache<FilmDto>(id, wookiee)).Returns(cachedItem);

        // Act
        var result = await _apiService.GetByIdAsync<FilmDto>(uri, id, wookiee);

        // Assert
        Assert.NotNull(result);
        Assert.That(result.Id, Is.EqualTo(cachedItem.Id));
    }

    [Test]
    public async Task GetByIdAsync_ShouldRetrieveFromRestServiceAndCache()
    {
        // Arrange
        var uri = "https://swapi.dev/api/films";
        var id = 1;
        var wookiee = false;
        var itemToRetrieve = new FilmDto { EpisodeId = 1 , Url = "https://swapi.dev/api/films/1"};

        _cacheServiceMock.Setup(c => c.GetItemInCache<FilmDto>(id, wookiee)).Returns((FilmDto?)null);

        _restServiceMock.Setup(r => r.GetAsync<FilmDto>($"{uri}/{id}", wookiee)).ReturnsAsync(itemToRetrieve);

        // Act
        var result = await _apiService.GetByIdAsync<FilmDto>(uri, id, wookiee);

        // Assert
        Assert.NotNull(result);
        Assert.That(result.Id, Is.EqualTo(itemToRetrieve.Id));
        _cacheServiceMock.Verify(c => c.SetItemInCache(itemToRetrieve, wookiee), Times.Once);
    }
}