using Microsoft.AspNetCore.Mvc;
using Shorify.Application.User.Queries;

namespace Shorify.WebApi.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController:ApiBaseController
{

    [HttpGet]
    [Route("get-by-id/{id}")]
    public async Task<IActionResult> GetUserById(string id)
    {
        var query = new GetUserByIdQuery()
        {
            Id = id
        };

        return Ok(await Mediator.Send(query));
    }
}
