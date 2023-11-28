using System.ComponentModel;
using Shared.Domain.ValueObject;

namespace Security.Auth.Domain.ValueObject;

public class UserSecurityHashPassword : StringValueObject
{
    private const int MIN_PASSWORD_LENGTH = 16;

    public UserSecurityHashPassword(string value) : base(value)
    {
        EnsureMinPasswordLength(value);
    }

    private UserSecurityHashPassword()
    {
        
    }

    private void EnsureMinPasswordLength(string value)
    {
        if (value.Length < MIN_PASSWORD_LENGTH)
            throw new InvalidEnumArgumentException($"the password should at least {MIN_PASSWORD_LENGTH}");
    }
    
}