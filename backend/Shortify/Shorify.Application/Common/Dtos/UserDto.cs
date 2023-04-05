
using Shortify.Common.Enums;

namespace Shorify.Application.Common.Dtos;

public class UserDto
{
    public string Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public Roles Role { get; set; }
}
