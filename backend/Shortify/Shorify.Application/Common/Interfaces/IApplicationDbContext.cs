using Microsoft.EntityFrameworkCore;
using Shorify.Domain.Entities;

namespace Shorify.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Domain.Entities.AlgorithmDescription> AlgorithmDescriptions { get; set; }
    DbSet<Domain.Entities.User> Users { get; set; }
    DbSet<ShortenedUrlInstance> ShortenedUrls { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
