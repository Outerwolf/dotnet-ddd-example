using MediatR;

namespace Security.Auth.Application.RegisterUser;

public class RegisterUserHandler: IRequestHandler<RegisterUserCommand>
{
    private readonly RegisterUser _registerUser;
    
    public RegisterUserHandler(RegisterUser registerUser)
    {
        _registerUser = registerUser;
    }
    public async Task Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        await _registerUser.Execute(Username: request.Username, Password: request.Password, Role: request.Role,
            Identification: request.Identification, cancellationToken);
    }
}