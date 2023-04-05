using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Shortify.Common.ClaimNames;

namespace Shortify.Infrastucture.Authorization;

public class RoleAuthorizationHandler : AuthorizationHandler<RoleRequirement>
{
    
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleRequirement requirement)
    {
        var role = context.User.Claims.FirstOrDefault(x => x.Type == ClaimNames.ROLE)?.Value;
        if(role == requirement.Role)
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}
