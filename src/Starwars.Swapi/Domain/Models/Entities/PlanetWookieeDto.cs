using Starwars.Swapi.Domain.Utils;

namespace Starwars.Swapi.Domain.Models.Entities;

public class PlanetWookieeDto : IRepositoryModel
{
    public int Id => RegexUtils.GetIdFromUrl(Hurcan);

    [JsonPropertyName("whrascwo")]
    public string Whrascwo { get; set; }
    [JsonPropertyName("rcooaoraaoahoowh_akworcahoowa")]
    public string RcooaoraaoahoowhAkworcahoowa { get; set; }
    [JsonPropertyName("oorcrhahaoraan_akworcahoowa")]
    public string OorcrhahaoraanAkworcahoowa { get; set; }
    [JsonPropertyName("waahrascwoaoworc")]
    public string Waahrascwoaoworc { get; set; }
    [JsonPropertyName("oaanahscraaowo")]
    public string Oaanahscraaowo { get; set; }
    [JsonPropertyName("rrrcrahoahaoro")]
    public string Rrrcrahoahaoro { get; set; }
    [JsonPropertyName("aoworcrcraahwh")]
    public string Aoworcrcraahwh { get; set; }
    [JsonPropertyName("churcwwraoawo_ohraaoworc")]
    public string ChurcwwraoawoOhraaoworc { get; set; }
    [JsonPropertyName("akooakhuanraaoahoowh")]
    public string Akooakhuanraaoahoowh { get; set; }
    [JsonPropertyName("rcwocahwawowhaoc")]
    public IEnumerable<string> Rcwocahwawowhaoc { get; set; }
    [JsonPropertyName("wwahanscc")]
    public IEnumerable<string> Wwahanscc { get; set; }
    [JsonPropertyName("oarcworaaowowa")]
    public string Oarcworaaowowa { get; set; }
    [JsonPropertyName("wowaahaowowa")]
    public string Wowaahaowowa { get; set; }
    [JsonPropertyName("hurcan")]
    public string Hurcan { get; set; }
}