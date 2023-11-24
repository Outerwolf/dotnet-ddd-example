using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Security.Auth.Domain;
using Security.Auth.Domain.ValueObject;

namespace Security.Auth.Infrastructure.Persitance.Configurations;

public class UserSecurityConfigurations: IEntityTypeConfiguration<UserSecurity>
{
    public void Configure(EntityTypeBuilder<UserSecurity> builder)
    {
        ConfigureSecurityAuthTable(builder);
    }

    private void ConfigureSecurityAuthTable(EntityTypeBuilder<UserSecurity> builder)
    {
        builder.ToTable("UsersSecurity");
        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
            .IsRequired()
            .HasColumnName("UserId") // Cambia el nombre de la columna si es necesario
            .HasConversion(
                id => id.Value,
                value => new UserSecurityId(value));
        builder.Property(m => m.Identification)
            .HasConversion(
                identification => identification.Value,
                value => new UserSecurityIdentification(value))
            .HasMaxLength(128);
        builder.Property(m => m.UserName)
            .HasConversion(
                username => username.Value,
                value => new UserSecurityUserName(value))
            .HasMaxLength(128);
        builder.Property(m => m.Password)
            .HasConversion(
                password => password.Value,
                value => new UserSecurityPassword(value))
            .HasMaxLength(128);
        builder.Property(m => m.Role)
            .HasConversion(
                role => role.Value,
                value => new UserSecurityRole(value))
            .HasMaxLength(128);
    }
}