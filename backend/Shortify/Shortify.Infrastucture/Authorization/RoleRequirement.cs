using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Shortify.Infrastucture.Authorization;

public class RoleRequirement:IAuthorizationRequirement
{
    public string Role { get; set; }
}
