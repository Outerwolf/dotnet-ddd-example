namespace Security.Auth.Infrastructure.Security;

public interface IPasswordHasher
{
    string ComputeHash(string password, string salt, int iteration);
    string GenerateSalt();
}