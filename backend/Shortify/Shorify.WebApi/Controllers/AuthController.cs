using Microsoft.AspNetCore.Mvc;
using Shorify.Application.User.Commands;

namespace Shorify.WebApi.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController:ApiBaseController
{

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(LoginUserCommand request)
    {
        var result = await Mediator.Send(request);
        return result.IsSuccessfull ? Ok(result) : BadRequest(result);
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register(RegisterUserCommand request)
    {
        var result = await Mediator.Send(request);
        return result.IsSuccessfull ? Ok(result) : BadRequest(result);
    }
}