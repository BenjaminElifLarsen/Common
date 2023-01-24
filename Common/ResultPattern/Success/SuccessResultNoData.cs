using Common.ResultPattern.Enums;

namespace Common.ResultPattern;

public class SuccessResultNoData : Result
{
    public SuccessResultNoData()
    {

    }

    public override ResultType ResultType => ResultType.SuccessNotData;

    public override string[] Errors => default;
}
