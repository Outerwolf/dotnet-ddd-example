using MediatR;
using Microsoft.AspNetCore.Mvc;
using Security.Application.CreateUserSecurity;

namespace HomeIoT.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UserSecurityController : ControllerBase
{
    private readonly IMediator _mediator;
    public UserSecurityController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost(Name = "SignUp")]
    public Task SignUp([FromBody] UserSecurityDto req, CancellationToken cancellationToken)
    {
        return _mediator.Send(new CreateUserCommand(req.Username, req.Password, req.Role), cancellationToken);
    }
}