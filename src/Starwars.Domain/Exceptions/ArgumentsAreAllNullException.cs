namespace Starwars.Domain.Exceptions;

public class ArgumentsAreAllNullException : Exception
{
    public ArgumentsAreAllNullException() : base("All arguments are null")
    {
    }
}