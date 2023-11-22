namespace Security.Auth.Domain.Interface;

public interface SecurityAuthRepository
{
    Task Save(SecurityAuth securityAuth, CancellationToken cancellationToken);
    Task<SecurityAuth?> Find(SecurityAuthIdentification securityAuthIdentification, CancellationToken cancellationToken);
}