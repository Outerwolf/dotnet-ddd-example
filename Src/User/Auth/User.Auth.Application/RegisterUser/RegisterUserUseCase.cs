using Microsoft.AspNetCore.Http;
using Security.Auth.Domain;
using Security.Auth.Domain.Interface;
using Security.Auth.Domain.ValueObject;
using Security.Auth.Infrastructure.Security;

namespace Security.Auth.Application.RegisterUser;
public class RegisterUserUseCase
{
    private readonly UserSecurityRepository _userSecurityRepository;
    private readonly IPasswordHasher _passwordHasher;

    public RegisterUserUseCase(UserSecurityRepository userSecurityRepository, IPasswordHasher passwordHasher)
    {
        _userSecurityRepository = userSecurityRepository;
        _passwordHasher = passwordHasher;
    }
    public async Task Execute(string Username, string Password, string Role, string Identification, CancellationToken cancellationToken)
    {

        var security = await _userSecurityRepository.Find(new UserSecurityIdentification(Identification), cancellationToken);

        if (security != null)
        {
            throw new BadHttpRequestException("tester");
        }

        string salt = _passwordHasher.GenerateSalt();

        string pass = _passwordHasher.ComputeHash(Password, salt,10);
        
        var securityAuth = UserSecurity.Create(
            username: Username, 
            hashPassword: pass, 
            saltPassword: salt, 
            role: Role, 
            identification: Identification
            );
        await _userSecurityRepository.Save(securityAuth, cancellationToken);
    }
    
}
