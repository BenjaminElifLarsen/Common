using Common.Helpers;
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