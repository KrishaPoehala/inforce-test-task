using Shorify.Domain.Common;

namespace Shorify.Domain.Entities;

public class ShortenedUrlInstance: BaseEntity
{
    public string OriginalUrl { get; set; }
    public string ShortenedUrl { get; set; }
    public string CreatedById { get; set; }
    public User CreatedBy { get; set; }
}
