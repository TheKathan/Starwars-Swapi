namespace Starwars.Domain.Exceptions;

public class ArgumentOutsideRangeArrayException : ArgumentException
{
    public readonly int? Limit;
    public ArgumentOutsideRangeArrayException(string symbolName, int limit) 
        : base("Argument value is outside of allowed range", symbolName)
    {
        Limit = limit;
    }
}