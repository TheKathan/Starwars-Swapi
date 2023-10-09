using Starwars.Swapi.Domain.Exceptions;

namespace Starwars.Swapi.Domain.Utils;

public abstract class ValidationUtils
{
    public static void ResponseNotNull([NotNull]object? value)
    {
        if (value == null) throw new ResponseNullException();
    }
    
    public static void SuccessfulRequest(HttpResponseMessage response, string responseBody)
    {
        if (!response.IsSuccessStatusCode)
            throw new HttpRequestException($"Request not successful. Response : {responseBody}", null, response.StatusCode);
    }
    
    public static void ResourceFoundRequest(HttpResponseMessage response, string responseBody)
    {
        if (response.StatusCode.Equals(HttpStatusCode.NotFound))
            throw new HttpRequestException($"Request resource is not found. Response : {responseBody}", null, response.StatusCode);
    }
}