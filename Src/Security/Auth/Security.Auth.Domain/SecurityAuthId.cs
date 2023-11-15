using Shared.Domain.ValueObject;

namespace Security.Auth.Domain;

public class SecurityAuthId: Uuid
{
    public SecurityAuthId(string value) : base(value)
    {
    }
}