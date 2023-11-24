using Microsoft.AspNetCore.Http;
using Security.Auth.Domain;
using Security.Auth.Domain.Interface;
using Security.Auth.Domain.ValueObject;

namespace Security.Auth.Application.RegisterUser;
public class RegisterUser
{
    private readonly UserSecurityRepository _userSecurityRepository;

    public RegisterUser(UserSecurityRepository userSecurityRepository)
    {
        _userSecurityRepository = userSecurityRepository;
    }
    public async Task Execute(string Username, string Password, string Role, string Identification, CancellationToken cancellationToken)
    {

        var security = await _userSecurityRepository.Find(new UserSecurityIdentification(Identification), cancellationToken);

        if (security != null)
        {
            throw new BadHttpRequestException("tester");
        }
        
        var securityAuth = UserSecurity.Create(username: Username, keyPass: Password, role: Role, identification: Identification);
        await _userSecurityRepository.Save(securityAuth, cancellationToken);
    }
    
}
