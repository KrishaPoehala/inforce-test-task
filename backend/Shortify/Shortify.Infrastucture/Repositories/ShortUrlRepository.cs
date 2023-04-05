using Microsoft.EntityFrameworkCore;
using Shorify.Application.Common.Interfaces;
using Shorify.Domain.Entities;
using Shorify.Domain.Repositories;

namespace Shortify.Infrastucture.Repositories;

public class ShortUrlRepository : IShortUrlsRepository
{
    private readonly IApplicationDbContext _context;

    public ShortUrlRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    public void Add(ShortenedUrlInstance shortenedUrl) => _context.ShortenedUrls.Add(shortenedUrl);

    public async Task<bool> ExistByOriginalUrl(string originalUrl, CancellationToken cancellationToken) =>
        await _context.ShortenedUrls.AnyAsync(x => x.OriginalUrl == originalUrl, cancellationToken);

    public IQueryable<ShortenedUrlInstance> GetAll() => _context.ShortenedUrls.Include(x => x.CreatedBy);

    public async Task<ShortenedUrlInstance> GetById(string id, CancellationToken cancellationToken) =>
        await _context.ShortenedUrls.FirstAsync(x => x.Id == id,cancellationToken);

    public void Remove(ShortenedUrlInstance shortenedUrl) => _context.ShortenedUrls.Remove(shortenedUrl);
}
