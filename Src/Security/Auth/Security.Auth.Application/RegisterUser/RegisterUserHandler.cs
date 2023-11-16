using MediatR;

namespace Security.Auth.Application.RegisterUser;

public class RegisterUserHandler: IRequestHandler<RegisterUserCommand>
{
    private readonly RegisterUser _registerUser;
    
    public RegisterUserHandler(RegisterUser registerUser)
    {
        _registerUser = registerUser;
    }
    public Task Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        _registerUser.Execute(Username: request.Username, Password: request.Password, Role: request.Role,
            Identification: request.Identification);
        return Task.CompletedTask;
    }
}