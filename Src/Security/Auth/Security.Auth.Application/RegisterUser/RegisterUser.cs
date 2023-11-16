using Security.Auth.Domain;

namespace Security.Auth.Application.RegisterUser;


// public interface IRegisterUser
// {
//     Task Execute(string Username, string Password, string Role, string Identification);
// }
public class RegisterUser
{
    public Task Execute(string Username, string Password, string Role, string Identification)
    {
        var securityAuth = SecurityAuth.Create(username: Username, keyPass: Password, role: Role, identification: Identification);
        
        return Task.CompletedTask;
    }
    
}
