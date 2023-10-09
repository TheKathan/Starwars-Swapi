namespace Starwars.Swapi.Domain.Models.Entities;

public class SpecieDto : IRepositoryModel
{
    public int Id => RegexUtils.GetIdFromUrl(Url);

    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("classification")]
    public string Classification { get; set; }
    [JsonPropertyName("designation")]
    public string Designation { get; set; }
    [JsonPropertyName("average_height")]
    public string AverageHeight { get; set; }
    [JsonPropertyName("skin_colors")]
    public string SkinColors { get; set; }
    [JsonPropertyName("hair_colors")]
    public string HairColors { get; set; }
    [JsonPropertyName("eye_colors")]
    public string EyeColors { get; set; }
    [JsonPropertyName("average_lifespan")]
    public string AverageLifespan { get; set; }
    [JsonPropertyName("homeworld")]
    public string Homeworld { get; set; }
    [JsonPropertyName("language")]
    public string Language { get; set; }
    [JsonPropertyName("people")]
    public IEnumerable<string> People { get; set; }
    [JsonPropertyName("films")]
    public IEnumerable<string>? Films { get; set; }
    [JsonPropertyName("created")]
    public string Created { get; set; }
    [JsonPropertyName("edited")]
    public string Edited { get; set; }
    [JsonPropertyName("url")]
    public string Url { get; set; }
}