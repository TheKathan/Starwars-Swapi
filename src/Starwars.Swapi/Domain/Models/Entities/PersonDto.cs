namespace Starwars.Swapi.Domain.Models.Entities;

public class PersonDto : IRepositoryModel
{
    public int Id => RegexUtils.GetIdFromUrl(Url);
    
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("height")]
    public string Height { get; set; }
    [JsonPropertyName("mass")]
    public string Mass { get; set; }
    [JsonPropertyName("hair_color")]
    public string HairColor { get; set; }
    [JsonPropertyName("skin_color")]
    public string SkinColor { get; set; }
    [JsonPropertyName("eye_color")]
    public string EyeColor { get; set; }
    [JsonPropertyName("birth_year")]
    public string BirthYear { get; set; }
    [JsonPropertyName("gender")]
    public string Gender { get; set; }
    [JsonPropertyName("homeworld")]
    public string Homeworld { get; set; }
    [JsonPropertyName("films")]
    public IEnumerable<string>? Films { get; set; }
    [JsonPropertyName("species")]
    public IEnumerable<string>? Species { get; set; }
    [JsonPropertyName("vehicles")]
    public IEnumerable<string>? Vehicles { get; set; }
    [JsonPropertyName("starships")]
    public IEnumerable<string>? Starships { get; set; }
    [JsonPropertyName("created")]
    public string Created { get; set; }
    [JsonPropertyName("edited")]
    public string Edited { get; set; }
    [JsonPropertyName("url")]
    public string Url { get; set; }
}