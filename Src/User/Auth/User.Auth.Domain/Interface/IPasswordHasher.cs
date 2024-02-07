namespace Security.Auth.Domain.Interface;

public interface IPasswordHasher
{
    string ComputeHash(string password, string salt, int iteration);
    string GenerateSalt();
}