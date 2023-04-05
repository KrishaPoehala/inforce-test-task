using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shorify.Application.ShortUrls.Commands;
using Shorify.Application.ShortUrls.Queries;

namespace Shorify.WebApi.Controllers;

[ApiController]
[Route("api/urls")]
public class ShortUrlsController: ApiBaseController
{
    [HttpGet]
    [Route("all")]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllUrlsQuery();
        return Ok(await Mediator.Send(query));
    }

    [HttpPost]
    [Route("create")]
    [Authorize]
    public async Task<IActionResult> Create(CreateShortUrlCommand command)
    {
        var result = await Mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete]
    [Route("delete/{id}")]
    [Authorize]
    public async Task<IActionResult> Delete(string id)
    {
        var command = new DeleteShortUrlCommand()
        {
            ShortUrlId = id,
        };

        await Mediator.Send(command);
        return Ok();
    }
}
