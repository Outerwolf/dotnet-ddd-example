using Security.Auth.Domain.ValueObject;

namespace Security.Auth.Domain.Interface;

public interface UserSecurityRepository
{
    Task Save(UserSecurity userSecurity, CancellationToken cancellationToken);
    Task<UserSecurity?> Find(UserSecurityIdentification userSecurityIdentification, CancellationToken cancellationToken);
}