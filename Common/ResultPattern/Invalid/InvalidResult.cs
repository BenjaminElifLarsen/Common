using Common.ResultPattern.Enums;

namespace Common.ResultPattern;

public class InvalidResult<T> : Result<T>
{
    private readonly string[] _errors;

    public InvalidResult(params string[] errors)
    {
        _errors = errors;
    }

    public override ResultTypes ResultType => ResultTypes.Invalid;

    public override string[] Errors => _errors;

    public override T Data => default;
}
