namespace Starwars.Swapi.Domain.Models.Entities;

public class StarShipWookieeDto : IRepositoryModel
{
    public int Id => RegexUtils.GetIdFromUrl(Hurcan);

    [JsonPropertyName("whrascwo")]
    public string Whrascwo { get; set; }
    [JsonPropertyName("scoowawoan")]
    public string Scoowawoan { get; set; }
    [JsonPropertyName("scrawhhuwwraoaaohurcworc")]
    public string Scrawhhuwwraoaaohurcworc { get; set; }
    [JsonPropertyName("oaoocao_ahwh_oarcwowaahaoc")]
    public string OaoocaoAhwhOarcwowaahaoc { get; set; }
    [JsonPropertyName("anwowhrraoac")]
    public string Anwowhrraoac { get; set; }
    [JsonPropertyName("scrak_raaoscoocakacworcahwhrr_cakwowowa")]
    public string ScrakRaaoscoocakacworcahwhrrCakwowowa { get; set; }
    [JsonPropertyName("oarcwooh")]
    public string Oarcwooh { get; set; }
    [JsonPropertyName("akraccwowhrrworcc")]
    public string Akraccwowhrrworcc { get; set; }
    [JsonPropertyName("oararcrroo_oaraakraoaahaoro")]
    public string OararcrrooOaraakraoaahaoro { get; set; }
    [JsonPropertyName("oaoowhchuscrarhanwoc")]
    public string Oaoowhchuscrarhanwoc { get; set; }
    [JsonPropertyName("acroakworcwarcahhowo_rcraaoahwhrr")]
    public string AcroakworcwarcahhowoRcraaoahwhrr { get; set; }
    [JsonPropertyName("MGLT")]
    public string Mglt { get; set; }
    [JsonPropertyName("caorarccacahak_oaanracc")]
    public string CaorarccacahakOaanracc { get; set; }
    [JsonPropertyName("akahanooaoc")]
    public IEnumerable<string> Akahanooaoc { get; set; }
    [JsonPropertyName("wwahanscc")]
    public IEnumerable<string> Wwahanscc { get; set; }
    [JsonPropertyName("oarcworaaowowa")]
    public string Oarcworaaowowa { get; set; }
    [JsonPropertyName("wowaahaowowa")]
    public string Wowaahaowowa { get; set; }
    [JsonPropertyName("hurcan")]
    public string Hurcan { get; set; }
}