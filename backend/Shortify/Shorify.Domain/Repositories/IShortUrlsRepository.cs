using Shorify.Domain.Entities;

namespace Shorify.Domain.Repositories;

public interface IShortUrlsRepository
{
    void Add(ShortenedUrlInstance shortenedUrl);
    Task<ShortenedUrlInstance> GetById(string id,CancellationToken cancellationToken);
    void Remove(ShortenedUrlInstance shortenedUrl);
    IQueryable<ShortenedUrlInstance> GetAll();
    Task<bool> ExistByOriginalUrl(string email,CancellationToken cancellationToken);
}
