using Common.ResultPattern;

namespace Common.ProcessManager;
public class ReturnEvent
{
    public Result Result { get; }

	public ReturnEvent(Result result)
	{
		Result = result;
	}
}
