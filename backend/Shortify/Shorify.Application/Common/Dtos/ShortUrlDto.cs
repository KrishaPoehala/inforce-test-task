namespace Shorify.Application.Common.Dtos;

public class ShortUrlDto
{
    public string  Id { get; set; }
    public string OriginalUrl { get; set; }
    public string ShortenedUrl { get; set; }
    public string CreatedById { get; set; }
    public UserDto CreatedBy { get; set; }
}
