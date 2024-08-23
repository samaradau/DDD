namespace DDD.Domain.Exceptions;

public class InvalidVersionFormatException : FormatException
{
    public InvalidVersionFormatException(string message) : base(message) { }
}
