namespace Common.Helpers;
internal class EnumConversion
{
    internal static long EnumToLong(Enum e)
    {
        var value = Convert.ChangeType(e, Enum.GetUnderlyingType(e.GetType()));
        return Convert.ToInt64(value);
    }
}
