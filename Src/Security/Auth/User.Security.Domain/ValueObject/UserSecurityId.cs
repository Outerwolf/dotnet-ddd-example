using Shared.Domain.ValueObject;

namespace Security.Auth.Domain.ValueObject;

public class UserSecurityId: Uuid
{
    public UserSecurityId(string value) : base(value)
    {
    }

    private UserSecurityId()
    {
        
    }

    public static UserSecurityId Create(string value)
    {
        return new UserSecurityId(value);
    }
}