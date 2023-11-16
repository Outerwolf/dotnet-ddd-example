using System.ComponentModel;
using Shared.Domain.ValueObject;

namespace Security.Auth.Domain;

public class SecurityAuthIdentification: StringValueObject
{
    public SecurityAuthIdentification(string value) : base(value)
    {
        EnsureIdentificationIsNotEmpty(value);
    }

    private void EnsureIdentificationIsNotEmpty(string value)
    {
        if( value == null )
            throw new InvalidEnumArgumentException($"the identification should not be empty");
    }
}