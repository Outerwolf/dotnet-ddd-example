using Security.Auth.Domain.ValueObject;
using Shared.Domain.AggregateRoot;
using Shared.Domain.ValueObject;

namespace Security.Auth.Domain;

public class UserSecurity : AggregateRoot<UserSecurityId>
{
    public UserSecurityUserName UserName { get; private set;}
    public UserSecurityPassword Password { get; private set;}
    public UserSecurityRole Role { get; private set;}
    
    public UserSecurityIdentification Identification { get; }

    public UserSecurity()
    {
        
    }
    
    protected UserSecurity(UserSecurityId id, UserSecurityUserName username,
        UserSecurityPassword password, UserSecurityRole role, UserSecurityIdentification identification): base(id)
    {
        UserName = username;
        Password = password;
        Role = role;
        Identification = identification;
    }

    public static UserSecurity Create(string identification, string username, string keyPass, string role)
    {
        var securityAuth = new UserSecurity(
            new UserSecurityId(Uuid.Random().Value),
            new UserSecurityUserName(username),
            new UserSecurityPassword(keyPass),
            new UserSecurityRole(role),
            new UserSecurityIdentification(identification)
        );
        // securityAuth.Record(new SecurityAuthCreatedDomainEvent(securityAuth.Id.Value, securityAuth.UserName.Value));

        return securityAuth;
    }
    
}