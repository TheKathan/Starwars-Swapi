namespace Starwars.Swapi.Domain.Utils;

public class RegexUtils
{
    public static int GetIdFromUrl(string url)
    {
        var regex = new Regex(@"\/(\d+)(?=\/|\?|$)");
        var match = regex.Match(url);

        if (!match.Success) return -1;
        
        var idString = match.Groups[1].Value;
        if (int.TryParse(idString, out var id))
        {
            return id;
        }
        return -1;
    }
}