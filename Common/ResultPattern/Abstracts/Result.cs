using Common.ResultPattern.Enums;

namespace Common.ResultPattern;

public abstract class Result<T>
{
    public abstract ResultType ResultType { get; }
    public abstract string[] Errors { get; }
    public abstract T Data { get; }
}

public abstract class Result : Result<object>
{
    public override object Data => default;
}
