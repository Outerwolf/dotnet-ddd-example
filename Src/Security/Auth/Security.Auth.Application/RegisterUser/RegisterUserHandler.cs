using MediatR;

namespace Security.Auth.Application.RegisterUser;

public class RegisterUserHandler: IRequestHandler<RegisterUserCommand>
{
    public Task Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}