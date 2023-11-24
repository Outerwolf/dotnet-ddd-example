using Shared.Domain.ValueObject;

namespace Shared.Domain.AggregateRoot;

public abstract class AggregateRoot<TId>: Entity<TId>
    where TId: notnull
{
    private List<DomainEvent> _domainEvents = new List<DomainEvent>();

    protected AggregateRoot(TId id): base(id)
    {
        
    }
    protected AggregateRoot()
    {
        
    }
    public List<DomainEvent> PullDomainEvents()
    {
        var events = _domainEvents;

        _domainEvents = new List<DomainEvent>();

        return events;
    }

    protected void Record(DomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}