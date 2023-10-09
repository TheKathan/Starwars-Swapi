namespace Starwars.Swapi.Domain.Exceptions;

public class ResponseNullException : Exception
{
    public ResponseNullException() : base("Request response returned empty")
    {
    }
}