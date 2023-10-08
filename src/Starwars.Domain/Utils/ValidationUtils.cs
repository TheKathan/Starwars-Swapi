using System.Diagnostics.CodeAnalysis;
using Starwars.Domain.Exceptions;

namespace Starwars.Domain.Utils;

public static class ValidationUtils
{
    public static void ArgumentNotNull([NotNull]object value, string parameterName)
    {
        if (value == null) throw new ArgumentNullException(parameterName);
    }
    
    public static void ResponseNotNull([NotNull]object value)
    {
        if (value == null) throw new ResponseNullException();
    }

    public static void SuccessfulRequest(HttpResponseMessage response, string responseBody)
    {
        if (!response.IsSuccessStatusCode)
            throw new HttpRequestException($"Request Not Successful. Response : {responseBody}", null, response.StatusCode);
    }

    public static void AuthorizedRequest(HttpResponseMessage response, string responseBody)
    {
        if (response.StatusCode.Equals(HttpStatusCode.Unauthorized))
            throw new UnauthorizedAccessException($"Request Not Authorized. Response : {responseBody}");
    }

    public static void ArgumentBelowLimit(long? value, string symbolName, int limit)
    {
        if (value > limit)
            throw new ArgumentAboveLimitException(symbolName, limit);
    }
    
    public static void ArgumentBetweenRange(long? value, string symbolName, int min, int max)
    {
        if (value < min || value > max)
            throw new ArgumentOutsideRangeException(symbolName, min, max);
    }

    public static void ArgumentInsideRangeArray(int value, string symbolName, IEnumerable<int> array)
    {
        if (!array.Contains(value))
            throw new ArgumentOutsideRangeArrayException(symbolName, value);
    }

    public static bool IsValidEmail(string email)
    {
        if (string.IsNullOrEmpty(email))
            return false;

        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
}