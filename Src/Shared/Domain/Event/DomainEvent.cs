namespace Shared.Domain.ValueObject;

public abstract class DomainEvent
{
    public string AggregateId { get; }
    public string EventId { get; }
    public string OccurredOn { get; }

    protected DomainEvent(string aggregateId, string eventId, string occurredAt)
    {
        AggregateId = aggregateId;
        EventId = eventId ?? Uuid.Random().Value;
        OccurredOn = occurredAt ?? Utils.DateToString(DateTime.Now);
    }

    protected DomainEvent()
    {
    }

    public abstract string EventName();
    public abstract Dictionary<string, string> ToPrimitives();

    public abstract DomainEvent FromPrimitives(string aggregateId, Dictionary<string, string> body, string eventId,
        string occurredOn);
}