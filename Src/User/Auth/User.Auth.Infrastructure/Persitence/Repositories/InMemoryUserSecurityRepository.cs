using Security.Auth.Domain;
using Security.Auth.Domain.Interface;
using Security.Auth.Domain.ValueObject;

namespace Security.Auth.Infrastructure.Persitence.Repositories;

public class InMemoryUserSecurityRepository : UserSecurityRepository
{
    private readonly List<UserSecurity> _savedSecurityAuths = new();
    public Task Save(UserSecurity userSecurity, CancellationToken cancellationToken)
    {
        _savedSecurityAuths.Add(userSecurity);
        return Task.CompletedTask;
    }

    public Task<UserSecurity?> Find(UserSecurityIdentification userSecurityIdentification,
        CancellationToken cancellationToken)
    {
        return Task.FromResult(_savedSecurityAuths.Find(x => x.Identification.Value == userSecurityIdentification.Value));
    }
}