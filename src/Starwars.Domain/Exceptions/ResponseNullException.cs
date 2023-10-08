namespace Starwars.Domain.Exceptions;

public class ResponseNullException : Exception
{
    public ResponseNullException() : base("Request response returned empty")
    {
        
    }
}