using Microsoft.AspNetCore.Authorization;
using Shortify.Common.Enums;

namespace Shortify.Infrastucture.Authorization;

public class IsInRoleAttribute:AuthorizeAttribute
{
    public IsInRoleAttribute(Roles role):base(policy: role.ToString())
    {
    }
}
