using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Shorify.WebApi.Controllers;

public class ApiBaseController:ControllerBase
{
    protected ISender Mediator => HttpContext.RequestServices.GetRequiredService<ISender>();
}