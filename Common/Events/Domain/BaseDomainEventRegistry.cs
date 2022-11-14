namespace Common.Events.Domain;
public abstract class BaseDomainEventRegistry
{
	protected readonly IDomainEventBus _domainEventBus;
	protected BaseDomainEventRegistry(IDomainEventBus domainEventBus)
	{
		_domainEventBus = domainEventBus;
	}

	public abstract void RegistrateEventHandlers();
	public abstract void UnregistrateEventHandlers();
}
