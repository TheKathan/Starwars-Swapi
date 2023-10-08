using Starwars.Swapi.Domain.Utils;

namespace Starwars.Swapi.Domain.Models.Entities;

public class SpecieWookieeDto : IRepositoryModel
{
    public int Id => RegexUtils.GetIdFromUrl(Hurcan);

    [JsonPropertyName("whrascwo")]
    public string Whrascwo { get; set; }
    [JsonPropertyName("oaanraccahwwahoaraaoahoowh")]
    public string Oaanraccahwwahoaraaoahoowh { get; set; }
    [JsonPropertyName("wawocahrrwhraaoahoowh")]
    public string Wawocahrrwhraaoahoowh { get; set; }
    [JsonPropertyName("rahoworcrarrwo_acwoahrracao")]
    public string RahoworcrarrwoAcwoahrracao { get; set; }
    [JsonPropertyName("corahwh_oaooanoorcc")]
    public string CorahwhOaooanoorcc { get; set; }
    [JsonPropertyName("acraahrc_oaooanoorcc")]
    public string AcraahrcOaooanoorcc { get; set; }
    [JsonPropertyName("worowo_oaooanoorcc")]
    public string WorowoOaooanoorcc { get; set; }
    [JsonPropertyName("rahoworcrarrwo_anahwwwocakrawh")]
    public string RahoworcrarrwoAnahwwwocakrawh { get; set; }
    [JsonPropertyName("acooscwoohoorcanwa")]
    public string Acooscwoohoorcanwa { get; set; }
    [JsonPropertyName("anrawhrrhurarrwo")]
    public string Anrawhrrhurarrwo { get; set; }
    [JsonPropertyName("akwoooakanwo")]
    public IEnumerable<string> Akwoooakanwo { get; set; }
    [JsonPropertyName("wwahanscc")]
    public IEnumerable<string> Wwahanscc { get; set; }
    [JsonPropertyName("oarcworaaowowa")]
    public string Oarcworaaowowa { get; set; }
    [JsonPropertyName("wowaahaowowa")]
    public string Wowaahaowowa { get; set; }
    [JsonPropertyName("hurcan")]
    public string Hurcan { get; set; }
}