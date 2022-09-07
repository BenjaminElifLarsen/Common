using Common.ResultPattern.Enums;

namespace Common.ResultPattern;

public class NotFoundResult<T> : Result<T>
{
    private readonly string[] _errors;

    public NotFoundResult(params string[] errors)
    {
        _errors = errors;
    }

    public override ResultTypes ResultType => ResultTypes.NotFound;

    public override string[] Errors => _errors;

    public override T Data => default;
}
