using Security.Auth.Domain;
using Security.Auth.Domain.Interface;

namespace Security.Auth.Infrastructure.Persitance;

public class InMemorySecurityAuthRepository : SecurityAuthRepository
{
    private readonly List<SecurityAuth> _savedSecurityAuths = new();
    public Task Save(SecurityAuth securityAuth, CancellationToken cancellationToken)
    {
        _savedSecurityAuths.Add(securityAuth);
        return Task.CompletedTask;
    }

    public Task<SecurityAuth?> Find(SecurityAuthIdentification securityAuthIdentification,
        CancellationToken cancellationToken)
    {
        return Task.FromResult(_savedSecurityAuths.Find(x => x.Identification.Value == securityAuthIdentification.Value));
    }
}