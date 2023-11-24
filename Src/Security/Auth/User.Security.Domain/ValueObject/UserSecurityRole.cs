using System.ComponentModel;
using Shared.Domain.ValueObject;

namespace Security.Auth.Domain.ValueObject;

public class UserSecurityRole : StringValueObject
{
    private readonly IEnumerable<string> AuthRoles = new[] { "SUPER_ADMIN", "USER", "THIRD_PARTY" };

    public UserSecurityRole(string value) : base(value)
    {
        EnsureIsValidRole(value);
    }

    private UserSecurityRole()
    {
        
    }

    private void EnsureIsValidRole(string value)
    {
        if (!AuthRoles.Contains(value))
            throw new InvalidEnumArgumentException($"the role ${value} is not valid");
    }
}