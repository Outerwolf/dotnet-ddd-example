using Shared.Domain.ValueObject;

namespace Security.Auth.Domain;

public class UserSecuritySaltPassword: StringValueObject
{
    public UserSecuritySaltPassword(string value) : base(value)
    {
        
    }
}