using Common.Helpers;

namespace Common.BinaryFlags;
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

    private void AddFlag(long flag)
    {
        if ((_flag & flag) == 0)
            _flag += flag;
    }

    private bool IsFlagPresent(long flag)
    {
        return (_flag & flag) != 0;
    }

    #region Operators
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
        left.AddFlag(Convert.ToInt64(EnumConversion.EnumToLong(right)));
        return left;
    }

    public static bool operator ==(BinaryFlag left, Enum right)
    {
        return left.IsFlagPresent(EnumConversion.EnumToLong(right));
    }

    public static bool operator !=(BinaryFlag left, Enum right)
    {
        return !(left == right);
    }
    #endregion

    #region Cast Operators
    public static implicit operator long(BinaryFlag flag) => flag is not null ? flag._flag : 0;
    public static implicit operator BinaryFlag(long flag) => new(flag);
    public static implicit operator bool(BinaryFlag flag) => flag is not null && flag._flag == 0;
    #endregion
}