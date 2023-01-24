using Common.ResultPattern.Enums;

namespace Common.ResultPattern;

public class SuccessResult<T> : Result<T>
{
    private readonly T _data;

    public SuccessResult(T data)
    {
        _data = data;
    }

    public override ResultType ResultType => ResultType.Success;

    public override string[] Errors => default;

    public override T Data => _data;
}
