using Shared.Domain.ValueObject;

namespace Security.Auth.Domain.ValueObject;

public class UserSecuritySaltPassword: StringValueObject
{
    public UserSecuritySaltPassword(string value) : base(value)
    {
        
    }
}