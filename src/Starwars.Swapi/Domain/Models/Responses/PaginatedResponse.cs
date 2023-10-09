namespace Starwars.Swapi.Domain.Models.Responses;

public class PaginatedResponse<T>
{
    [JsonPropertyName("count")]
    public int Count { get; set; }
    [JsonPropertyName("next")]
    public string? Next { get; set; }
    [JsonPropertyName("previous")]
    public string? Previous { get; set; }
    [JsonPropertyName("results")]
    public IEnumerable<T>? Results { get; set; }
}