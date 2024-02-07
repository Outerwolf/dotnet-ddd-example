using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Security.Auth.Domain.Interface;

namespace Security.Auth.Infrastructure.Security;

public class PasswordHasherWithSaltAndPepper : IPasswordHasher
{
    private readonly IConfiguration _configuration;
    private string? _PEPPER = "";

    public PasswordHasherWithSaltAndPepper(IConfiguration configuration)
    {
        _configuration = configuration;
        _PEPPER = configuration.GetSection("Security:UserSecurity_Pepper").ToString();
    }
    public string ComputeHash(string password, string salt, int iteration)
    {
        if (iteration <= 0) return password;
        
        using var sha256 = SHA256.Create();
        var passwordSaltPepper = $"{password}{salt}{_PEPPER}";
        var byteValue = Encoding.UTF8.GetBytes(passwordSaltPepper);
        var byteHash = sha256.ComputeHash(byteValue);
        var hash = Convert.ToBase64String(byteHash);
        return ComputeHash(hash, salt, iteration - 1);
    }
    
    public string GenerateSalt()
    {
        using var rng = RandomNumberGenerator.Create();
        var byteSalt = new byte[16];
        rng.GetBytes(byteSalt);
        var salt = Convert.ToBase64String(byteSalt);
        return salt;
    }
}