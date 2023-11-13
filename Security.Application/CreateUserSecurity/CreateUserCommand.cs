using MediatR;

namespace Security.Application.CreateUserSecurity;

public record CreateUserCommand(string UserName, string Password, string Role): IRequest;