using Shorify.Application.Common.Interfaces;
using Shortify.Common.ClaimNames;

namespace Shorify.WebApi.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly HttpContext? _httpContext;
    public CurrentUserService(IHttpContextAccessor contextAccessor)
    {
        _httpContext = contextAccessor.HttpContext;
    }

    public string Id => _httpContext.User.Claims.First(x => x.Type == ClaimNames.ID).Value;
}