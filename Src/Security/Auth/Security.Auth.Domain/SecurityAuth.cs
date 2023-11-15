using System.Runtime.Serialization;
using Shared.Domain.AggregateRoot;

namespace Security.Auth.Domain;

public class SecurityAuth : AggregateRoot
{
    public SecurityAuthId Id { get; }
    public SecurityAuthUserName UserName { get; }
    public SecurityAuthKeyPass KeyPass { get; }
    public SecurityAuthRole Role { get; }

    protected SecurityAuth(SecurityAuthId id, SecurityAuthUserName username,
        SecurityAuthKeyPass keyPass, SecurityAuthRole role)
    {
        Id = id;
        UserName = username;
        KeyPass = keyPass;
        Role = role;
    }
    
}