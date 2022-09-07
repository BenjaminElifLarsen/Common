using Common.ResultPattern.Enums;

namespace Common.ResultPattern;

public class SuccessResultNoData : Result
{
    public SuccessResultNoData()
    {

    }

    public override ResultTypes ResultType => ResultTypes.SuccessNotData;

    public override string[] Errors => default;
}
