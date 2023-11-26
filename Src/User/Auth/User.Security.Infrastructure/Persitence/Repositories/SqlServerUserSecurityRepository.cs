using Microsoft.Extensions.Logging;
using Security.Auth.Domain;
using Security.Auth.Domain.Interface;
using Security.Auth.Domain.ValueObject;
using Security.Auth.Infrastructure.Persitance;

namespace Security.Auth.Infrastructure.Persitence.Repositories;

public class SqlServerUserSecurityRepository: UserSecurityRepository
{
    private readonly UserSecurityDbContext _dbContext;
    private readonly ILogger<SqlServerUserSecurityRepository> _logger;

    public SqlServerUserSecurityRepository(UserSecurityDbContext dbContext, ILogger<SqlServerUserSecurityRepository> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }
    public Task Save(UserSecurity userSecurity, CancellationToken cancellationToken)
    {
        _dbContext.Add(userSecurity);
        return _dbContext.SaveChangesAsync(cancellationToken).ContinueWith(
            action =>
            {
                if (action.Status == TaskStatus.Canceled)
                {
                    _logger.LogWarning($"Canceled to Save {userSecurity.Identification.Value}");
                }

                if (action.Status == TaskStatus.Faulted)
                {
                    _logger.LogError($"Occurred an error saving the user {action.Exception}");
                    throw new Exception("Occurred an error saving the user");
                }
            }, cancellationToken);
    }

    public async Task<UserSecurity?> Find(UserSecurityIdentification userSecurityIdentification, CancellationToken cancellationToken)
    {
        return _dbContext.UserSecurities.FirstOrDefault(u => u.Identification == userSecurityIdentification);
    }
}