using Common.RepositoryPattern;

namespace Common.Events.Store.Event;
public record DataPoint : ValueObject
{
    public int UniqueId { get; private set; }
    public string Value { get; private set; }

    public DataPoint(int uniqueId, string value)
    {
        UniqueId = uniqueId;
        Value = value;
    }

    public static bool operator ==(DataPoint left, Enum right)
    {
        return left.UniqueId == EnumConversion.EnumToLong(right);
    }

    public static bool operator !=(DataPoint left, Enum right)
    {
        return !(left == right);
    }
}

file class EnumConversion //File encapsulation is coming with C sharp 11, mainly meant for source files. Ensures a class is only visable inside its file.
{ //remember DRY, so move this into its own file with internal encapsulation
    public static long EnumToLong(Enum e)
    {
        var value = Convert.ChangeType(e, Enum.GetUnderlyingType(e.GetType()));
        return Convert.ToInt64(value);
    }
}