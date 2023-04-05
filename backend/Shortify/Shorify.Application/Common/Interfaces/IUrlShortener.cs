namespace Shorify.Application.Common.Interfaces;

public interface IUrlShortener
{
    string GenerateShortenedUrl(long id);
}