namespace Starwars.Swapi.Tests.Infrastructure;

[TestFixture]
public class RestServiceTests
{
    private Mock<ILogger<RestService>> _loggerMock;

    [SetUp]
    public void Setup()
    {
        _loggerMock = new Mock<ILogger<RestService>>();
    }

    [Test]
    public async Task GetAsync_ValidUri_ShouldDeserializeResponse()
    {
        // Arrange
        var uri = "https://test.com/api/resource";
        var wookiee = false;

        // Define a sample response JSON
        var responseJson = "{\"Name\":\"Luke Skywalker\",\"Gender\":\"Male\"}";

        // Create a mock HttpMessageHandler to simulate the HttpClient response
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(responseJson),
            });

        var httpClient = new HttpClient(mockHandler.Object);
        var restService = new RestService(_loggerMock.Object, httpClient);

        // Act
        var result = await restService.GetAsync<Person>(uri, wookiee);

        // Assert
        Assert.NotNull(result);
        Assert.That(result.Name, Is.EqualTo("Luke Skywalker"));
        Assert.That(result.Gender, Is.EqualTo("Male"));
    }

    [Test]
    public async Task GetAsync_InvalidUri_ShouldReturnDefault()
    {
        // Arrange
        var uri = "https://test.com/api/resource";
        var wookiee = false;

        // Create a mock HttpMessageHandler to simulate an exception when making the request
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .Throws(new Exception("Simulated exception"));

        var httpClient = new HttpClient(mockHandler.Object);
        var restService = new RestService(_loggerMock.Object, httpClient);

        // Act
        var result = await restService.GetAsync<Person>(uri, wookiee);

        // Assert
        Assert.Null(result);
    }
}