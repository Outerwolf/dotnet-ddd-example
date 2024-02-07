using Microsoft.EntityFrameworkCore;
using Security.Auth.Domain;

namespace Security.Auth.Infrastructure.Persitence;

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