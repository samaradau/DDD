using DDD.Domain.Exceptions;

namespace DDD.Domain.ValueObjects;

public readonly record struct Version(ushort Major, ushort Minor)
{
    public const char Separator = '.';

    public override string ToString()
    {
        return $"{Major}{Separator}{Minor}";
    }

    public static Version Parse(string version) 
    {
        _ = version ?? throw new ArgumentNullException(nameof(version));
        var splitted = version.Split(Separator);

        if (splitted.Length < 2) throw new InvalidVersionFormatException(nameof(version));

        ushort major, minor;
        try
        {
            major = ushort.Parse(splitted[0]);
            minor = ushort.Parse(splitted[1]);
        }
        catch(FormatException)
        {
            throw new InvalidVersionFormatException(nameof(version));
        }
        catch(OverflowException)
        {
            throw new VersionOverflowException();
        }

        return new Version(major, minor);
    }
    
    public static bool TryParse(string str, out Version? version) 
    {
        var result = true;
        version = default!;

        try
        {
            version = Parse(str);
        }
        catch(ArgumentNullException)
        {
            result = false;
        }
        catch(InvalidVersionFormatException)
        {
            result = false;
        }
        catch(VersionOverflowException)
        {
            result = false;
        }

        return result;
    }
}
