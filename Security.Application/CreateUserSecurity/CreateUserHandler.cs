using MediatR;

namespace Security.Application.CreateUserSecurity;

public class CreateUserHandler: IRequestHandler<CreateUserCommand>
{
    public Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        Console.WriteLine(request);
        return null;
    }
}