namespace Starwars.Swapi.Domain.Models.Entities;

public class FilmWookieeDto : IRepositoryModel
{
    public int Id => RegexUtils.GetIdFromUrl(Hurcan);

    [JsonPropertyName("aoahaoanwo")]
    public string Aoahaoanwo { get; set; }
    [JsonPropertyName("woakahcoowawo_ahwa")]
    public int WoakahcoowawoAhwa { get; set; }
    [JsonPropertyName("ooakwowhahwhrr_oarcraohan")]
    public string OoakwowhahwhrrOarcraohan { get; set; }
    [JsonPropertyName("waahrcwooaaooorc")]
    public string Waahrcwooaaooorc { get; set; }
    [JsonPropertyName("akrcoowahuoaworc")]
    public string Akrcoowahuoaworc { get; set; }
    [JsonPropertyName("rcwoanworacwo_waraaowo")]
    public string RcwoanworacwoWaraaowo { get; set; }
    [JsonPropertyName("oaacrarcraoaaoworcc")]
    public IEnumerable<string> Oaacrarcraoaaoworcc { get; set; }
    [JsonPropertyName("akanrawhwoaoc")]
    public IEnumerable<string> Akanrawhwoaoc { get; set; }
    [JsonPropertyName("caorarccacahakc")]
    public IEnumerable<string> Caorarccacahakc { get; set; }
    [JsonPropertyName("howoacahoaanwoc")]
    public IEnumerable<string> Howoacahoaanwoc { get; set; }
    [JsonPropertyName("cakwooaahwoc")]
    public IEnumerable<string> Cakwooaahwoc { get; set; }
    [JsonPropertyName("oarcworaaowowa")]
    public string Oarcworaaowowa { get; set; }
    [JsonPropertyName("wowaahaowowa")]
    public string Wowaahaowowa { get; set; }
    [JsonPropertyName("hurcan")]
    public string Hurcan { get; set; }
}