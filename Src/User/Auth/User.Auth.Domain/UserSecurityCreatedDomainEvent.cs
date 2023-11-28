using Shared.Domain.ValueObject;

namespace Security.Auth.Domain;


public class SecurityAuthCreatedPayload
{
    public string UserName;
}

public class UserSecurityCreatedDomainEvent: DomainEvent
{
    public SecurityAuthCreatedPayload payload { get; }
    
    public UserSecurityCreatedDomainEvent(string id, string username, string eventId = null, string occurredAt = null): base(id, eventId, occurredAt)
    {
        payload.UserName = username;
    }
    public override string EventName()
    {
        return "security.auth.created";
    }

    public override Dictionary<string, string> ToPrimitives()
    {
        return new Dictionary<string, string>()
        {
            {"UserName", payload.UserName},
        };
    }

    public override DomainEvent FromPrimitives(string aggregateId, Dictionary<string, string> body, string eventId, string occurredOn)
    {
        return new UserSecurityCreatedDomainEvent(aggregateId, body["username"], eventId, occurredOn);
    }
}
