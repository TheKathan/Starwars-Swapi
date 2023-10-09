namespace Starwars.Swapi.Domain.Models.Entities;

public class FilmDto : IRepositoryModel
{
    public int Id => RegexUtils.GetIdFromUrl(Url);
    
    [JsonPropertyName("title")]
    public string Title { get; set; }
    [JsonPropertyName("episode_id")]
    public int EpisodeId { get; set; }
    [JsonPropertyName("opening_crawl")]
    public string OpeningCrawl { get; set; }
    [JsonPropertyName("director")]
    public string Director { get; set; }
    [JsonPropertyName("producer")]
    public string Producer { get; set; }
    [JsonPropertyName("release_date")]
    public string ReleaseDate { get; set; }
    [JsonPropertyName("characters")]
    public IEnumerable<string> Characters { get; set; }
    [JsonPropertyName("planets")]
    public IEnumerable<string>? Planets { get; set; }
    [JsonPropertyName("starships")]
    public IEnumerable<string>? Starships { get; set; }
    [JsonPropertyName("vehicles")]
    public IEnumerable<string>? Vehicles { get; set; }
    [JsonPropertyName("species")]
    public IEnumerable<string>? Species { get; set; }
    [JsonPropertyName("created")]
    public string Created { get; set; }
    [JsonPropertyName("edited")]
    public string Edited { get; set; }
    [JsonPropertyName("url")]
    public string Url { get; set; }
}