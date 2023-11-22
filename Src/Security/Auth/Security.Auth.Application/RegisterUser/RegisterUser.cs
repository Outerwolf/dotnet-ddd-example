using Security.Auth.Domain;
using Security.Auth.Domain.Interface;

namespace Security.Auth.Application.RegisterUser;


// public interface IRegisterUser
// {
//     Task Execute(string Username, string Password, string Role, string Identification);
// }
public class RegisterUser
{
    private readonly SecurityAuthRepository _securityAuthRepository;

    public RegisterUser(SecurityAuthRepository securityAuthRepository)
    {
        _securityAuthRepository = securityAuthRepository;
    }
    public async Task Execute(string Username, string Password, string Role, string Identification, CancellationToken cancellationToken)
    {

        var security = await _securityAuthRepository.Find(new SecurityAuthIdentification(Identification), cancellationToken);

        if (security != null)
        {
            throw new Exception("tester");
        }
        
        var securityAuth = SecurityAuth.Create(username: Username, keyPass: Password, role: Role, identification: Identification);
        _securityAuthRepository.Save(securityAuth, cancellationToken);
    }
    
}
