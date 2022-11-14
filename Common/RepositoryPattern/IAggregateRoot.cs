using Common.Events.Domain; 

namespace Common.RepositoryPattern;
public interface IAggregateRoot
{
    public IEnumerable<IDomainEvent> Events { get; }
    public void AddDomainEvent(IDomainEvent eventItem);
    public void RemoveDomainEvent(IDomainEvent eventItem);
}
