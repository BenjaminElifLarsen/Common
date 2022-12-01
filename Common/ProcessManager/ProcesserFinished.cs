using Common.ResultPattern;

namespace Common.ProcessManager;
public class ProcesserFinished
{
    public Result Result { get; }

	public ProcesserFinished(Result result)
	{
		Result = result;
	}
}
