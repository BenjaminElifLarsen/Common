namespace Common.Events.Store.ProcessManager;
public abstract class BaseProcessManager
{
    public Guid ProcessManagerId { get; protected set; }
    public Guid CorrelationId { get; protected set; }
    //public abstract void SetUp(Guid correlationId);
    public Guid Versioning { get; protected set; } 
    
    protected BaseProcessManager()
    { //ORM 

    }

    public BaseProcessManager(Guid processManagerId, Guid correlationId/*, Guid versioning*/)
    { //when will this one be needed? 
        ProcessManagerId = processManagerId;
        CorrelationId = correlationId;
        Versioning = Guid.NewGuid();
    }

    public void GenerateNewVersioning() //should be called after validating the current versioning against the context
    {
        Versioning = Guid.NewGuid();
    }
}
