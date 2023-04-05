using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shorify.Application.AlgorithmDescription.Commands;
using Shorify.Application.AlgorithmDescription.Queries;
using Shortify.Infrastucture.Authorization;

namespace Shorify.WebApi.Controllers;

[ApiController]
[Route("api/description")]
public class DescriptionsController:ApiBaseController
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var query = new GetDescriptionQuery();
        return Ok(await Mediator.Send(query));
    }

    [HttpPut]
    [Route("edit")]
    [Authorize]
    [IsInRole(Shortify.Common.Enums.Roles.Admin)]
    public async Task<IActionResult> Edit(EditDescriptionCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
}
