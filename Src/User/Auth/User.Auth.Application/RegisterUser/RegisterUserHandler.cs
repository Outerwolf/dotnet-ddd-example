using MediatR;

namespace Security.Auth.Application.RegisterUser;

public class RegisterUserHandler: IRequestHandler<RegisterUserCommand>
{
    private readonly RegisterUserUseCase _registerUserUseCase;
    
    public RegisterUserHandler(RegisterUserUseCase registerUserUseCase)
    {
        _registerUserUseCase = registerUserUseCase;
    }
    public async Task Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        await _registerUserUseCase.Execute(Username: request.Username, Password: request.Password, Role: request.Role,
            Identification: request.Identification, cancellationToken);
    }
}