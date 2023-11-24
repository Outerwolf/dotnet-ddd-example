using System.ComponentModel;
using Shared.Domain.ValueObject;

namespace Security.Auth.Domain.ValueObject;

public class UserSecurityPassword : StringValueObject
{
    private const int MIN_PASSWORD_LENGTH = 16;
    private const int MAX_PASSWORD_LENGTH = 128;

    public UserSecurityPassword(string value) : base(value)
    {
        EnsureMinPasswordLength(value);
    }

    private UserSecurityPassword()
    {
        
    }

    private void EnsureMinPasswordLength(string value)
    {
        if (value.Length < MIN_PASSWORD_LENGTH)
            throw new InvalidEnumArgumentException($"the password should at least {MIN_PASSWORD_LENGTH}");
    }

    private void EnsureMaxPasswordLengthNotExceed(string value)
    {
        if (value.Length > MAX_PASSWORD_LENGTH)
            throw new InvalidEnumArgumentException($"the password should be less than {MAX_PASSWORD_LENGTH}");
    }
}