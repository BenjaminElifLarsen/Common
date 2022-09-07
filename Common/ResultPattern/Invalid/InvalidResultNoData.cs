using Common.ResultPattern.Enums;

namespace Common.ResultPattern;
public class InvalidResultNoData : Result
{
    private readonly string[] _errors;
    public InvalidResultNoData(params string[] errors)
    {
        _errors = errors;
    }

    public override ResultTypes ResultType => default;

    public override string[] Errors => _errors;
}
