namespace Common.Other;
public class BinaryFlag
{
    private long _flag;

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

    public static BinaryFlag operator +(BinaryFlag left, int right)
    {
        left.AddFlag(right);
        return left;
    }

    public static BinaryFlag operator +(BinaryFlag left, byte right)
    {
        left.AddFlag(right);
        return left;
    }

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
        return !left.IsFlagPresent(right);
    }
}
