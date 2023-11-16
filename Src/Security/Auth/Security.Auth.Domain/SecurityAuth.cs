using System.Runtime.Serialization;
using Shared.Domain.AggregateRoot;
using Shared.Domain.ValueObject;

namespace Security.Auth.Domain;

public class SecurityAuth : AggregateRoot
{
    public SecurityAuthId Id { get; }
    public SecurityAuthUserName UserName { get; }
    public SecurityAuthKeyPass KeyPass { get; }
    public SecurityAuthRole Role { get; }
    
    public SecurityAuthIdentification Identification { get; }

    protected SecurityAuth(SecurityAuthId id, SecurityAuthUserName username,
        SecurityAuthKeyPass keyPass, SecurityAuthRole role, SecurityAuthIdentification identification)
    {
        Id = id;
        UserName = username;
        KeyPass = keyPass;
        Role = role;
        Identification = identification;
    }

    public static SecurityAuth Create(string identification, string username, string keyPass, string role)
    {
        var securityAuth = new SecurityAuth(
            new SecurityAuthId(Uuid.Random().Value),
            new SecurityAuthUserName(username),
            new SecurityAuthKeyPass(keyPass),
            new SecurityAuthRole(role),
            new SecurityAuthIdentification(identification)
        );
        // securityAuth.Record(new SecurityAuthCreatedDomainEvent(securityAuth.Id.Value, securityAuth.UserName.Value));

        return securityAuth;
    }
    
}