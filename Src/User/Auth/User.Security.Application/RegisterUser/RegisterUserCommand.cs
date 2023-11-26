using MediatR;

namespace Security.Auth.Application.RegisterUser;

public record struct RegisterUserCommand(string Username, string Password, string Role, string Identification): IRequest;