﻿namespace Common.ProcessManager;
public interface IProcessManager //old design
{
    public Guid ProcessManagerId { get; }
    public Guid CorrelationId { get; }
    public bool Running { get; }
    public bool FinishedSuccessful { get; }
    public void SetUp(Guid correlationId);
    public void RegistrateHandler(Action<ProcesserFinished> handler);
    public void PublishEventIfPossible();
}
