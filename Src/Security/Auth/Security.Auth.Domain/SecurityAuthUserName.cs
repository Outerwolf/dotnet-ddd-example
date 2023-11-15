using System.ComponentModel;
using Shared.Domain.ValueObject;

namespace Security.Auth.Domain;

public class SecurityAuthUserName: StringValueObject
{
    private const int MIN_CHARACTERS = 5;
    private const int MAX_CHARACTERS = 255;
    public SecurityAuthUserName(string value) : base(value)
    {
        EnsureMinCharacters(value);
        EnsureMaxCharacters(value);
    }

    private void EnsureMinCharacters(string value)
    {
        if(value.Length < MIN_CHARACTERS) throw new InvalidEnumArgumentException($"the username should be less than {MIN_CHARACTERS}");
    }

    private void EnsureMaxCharacters(string value)
    {
        if (value.Length > MAX_CHARACTERS) throw new InvalidEnumArgumentException($"the username should be less than {MAX_CHARACTERS}");
    }
}