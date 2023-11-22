using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Security.Auth.Application.RegisterUser;

namespace WebApi.Security.Auth.Controller;

[ApiController]
[Route("api/[controller]")]
public class SecurityAuthController
{
    private readonly IMediator _mediator;
    public SecurityAuthController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost(Name = "SignUp")]
    public Task SignUp([FromBody] UserRegistrationDto req, CancellationToken cancellationToken)
    {
        
        return _mediator.Send(new RegisterUserCommand(req.Username, req.Password, req.Role, req.Identification), cancellationToken);
    }
}