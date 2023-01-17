using Common.ResultPattern;

namespace Common.ProcessManager;
public class ProcesserFinished
{ //old design
    public Result Result { get; }
	public Guid ProcessManagerId { get; }

	public ProcesserFinished(Result result, Guid processManagerId)
	{
		Result = result;
		ProcessManagerId = processManagerId;
	}
}
