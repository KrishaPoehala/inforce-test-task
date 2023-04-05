using Shorify.Domain.Common;
using Shortify.Common.Enums;

namespace Shorify.Domain.Entities;

public class User : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string HashedPassword { get; set; } = null!;
    public Roles Role { get; set; }   
    public ICollection<ShortenedUrlInstance> CreatedUrls { get; set; }
}