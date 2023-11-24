using Microsoft.EntityFrameworkCore;
using Security.Auth.Domain;

namespace Security.Auth.Infrastructure.Persitance;

public class UserSecurityDbContext : DbContext
{
    public UserSecurityDbContext(DbContextOptions<UserSecurityDbContext> options): base(options)
    {
        
    }

    public DbSet<UserSecurity> UserSecurities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserSecurityDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
    
}