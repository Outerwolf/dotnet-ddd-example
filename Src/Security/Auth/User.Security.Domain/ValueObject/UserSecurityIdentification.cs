using System.ComponentModel;
using Shared.Domain.ValueObject;

namespace Security.Auth.Domain.ValueObject;

public class UserSecurityIdentification: StringValueObject
{
    private UserSecurityIdentification()
    {
        
    }
    public UserSecurityIdentification(string value) : base(value)
    {
        EnsureIdentificationIsNotEmpty(value);
    }

    private void EnsureIdentificationIsNotEmpty(string value)
    {
        if( value == null )
            throw new InvalidEnumArgumentException($"the identification should not be empty");
    }
}