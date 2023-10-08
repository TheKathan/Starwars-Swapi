using Starwars.Swapi.Domain.Utils;

namespace Starwars.Swapi.Domain.Models.Entities;

public class PersonWookieeDto : IRepositoryModel
{
    public int Id => RegexUtils.GetIdFromUrl(Hurcan);

    [JsonPropertyName("whrascwo")]
    public string Whrascwo { get; set; }
    [JsonPropertyName("acwoahrracao")]
    public string Acwoahrracao { get; set; }
    [JsonPropertyName("scracc")]
    public string Scracc { get; set; }
    [JsonPropertyName("acraahrc_oaooanoorc")]
    public string AcraahrcOaooanoorc { get; set; }
    [JsonPropertyName("corahwh_oaooanoorc")]
    public string CorahwhOaooanoorc { get; set; }
    [JsonPropertyName("worowo_oaooanoorc")]
    public string WorowoOaooanoorc { get; set; }
    [JsonPropertyName("rhahrcaoac_roworarc")]
    public string RhahrcaoacRoworarc { get; set; }
    [JsonPropertyName("rrwowhwaworc")]
    public string Rrwowhwaworc { get; set; }
    [JsonPropertyName("acooscwoohoorcanwa")]
    public string Acooscwoohoorcanwa { get; set; }
    [JsonPropertyName("wwahanscc")]
    public IEnumerable<string> Wwahanscc { get; set; }
    [JsonPropertyName("cakwooaahwoc")]
    public IEnumerable<string> Cakwooaahwoc { get; set; }
    [JsonPropertyName("howoacahoaanwoc")]
    public IEnumerable<string> Howoacahoaanwoc { get; set; }
    [JsonPropertyName("caorarccacahakc")]
    public IEnumerable<string> Caorarccacahakc { get; set; }
    [JsonPropertyName("oarcworaaowowa")]
    public string Oarcworaaowowa { get; set; }
    [JsonPropertyName("wowaahaowowa")]
    public string Wowaahaowowa { get; set; }
    [JsonPropertyName("hurcan")]
    public string Hurcan { get; set; }
}