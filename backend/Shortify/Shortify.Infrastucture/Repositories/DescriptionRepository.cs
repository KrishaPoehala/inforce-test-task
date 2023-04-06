using Microsoft.EntityFrameworkCore;
using Shorify.Application.Common.Interfaces;
using Shorify.Domain.Entities;
using Shorify.Domain.Repositories;

namespace Shortify.Infrastucture.Repositories;

public class DescriptionRepository : IDescriptionRepository
{
    private readonly IApplicationDbContext _context;

    public DescriptionRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<AlgorithmDescription> Get(CancellationToken cancellationToken) =>
        await _context.AlgorithmDescriptions.SingleAsync();
}
