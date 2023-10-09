namespace Starwars.Domain.Exceptions;

public class ArgumentValueIsIncorrectException : ArgumentException
{
    public ArgumentValueIsIncorrectException(string symbolName) 
        : base("Argument value is incorrect", symbolName)
    {
    }
}