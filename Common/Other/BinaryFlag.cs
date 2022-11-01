namespace Common.Other;
public class BinaryFlag
{
    private long _flag;

    private BinaryFlag(long flag)
    {
        _flag = flag;       
    }

    public BinaryFlag()
    {
        _flag = 0;
    }

    public void AddFlag(long flag)
    {
        if ((_flag & flag) == 0)
            _flag += flag;
    }

    public bool IsFlagPresent(long flag)
    {
        return (_flag & flag) != 0;
    }

    //public static BinaryFlag operator +(BinaryFlag left, BinaryFlag right)
    //{
    //    left._flag |= right._flag;
    //    return left;
    //}

    public static BinaryFlag operator +(BinaryFlag left, long right)
    {
        left.AddFlag(right);
        return left;
    }

    public static bool operator ==(BinaryFlag left, long right)
    {
        return left.IsFlagPresent(right);
    }

    public static bool operator !=(BinaryFlag left, long right)
    {
        return !(left == right);
    }

    public static BinaryFlag operator +(BinaryFlag left, Enum right)
    {
        left.AddFlag(Convert.ToInt64(EnumToLong(right)));
        return left;
    }

    public static bool operator ==(BinaryFlag left, Enum right)
    {
        return left.IsFlagPresent(EnumToLong(right));
    }

    public static bool operator !=(BinaryFlag left, Enum right)
    {
        return !(left == right);
    }

    private static long EnumToLong(Enum e) //When file modifier arrive with C# 11 move this into a healper class
    {
        var value = Convert.ChangeType(e, Enum.GetUnderlyingType(e.GetType()));
        return Convert.ToInt64(value);
    }

    public static implicit operator long(BinaryFlag flag) => flag._flag;
    public static implicit operator BinaryFlag(long flag) => new(flag);
    public static implicit operator bool(BinaryFlag flag) => flag._flag == 0;
}
