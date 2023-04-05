using Shorify.Application.Common.Interfaces;
using Shorify.Domain.UnitOfWork;

namespace Shortify.Infrastucture.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly IApplicationDbContext _context;

    public UnitOfWork(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken) => _context.SaveChangesAsync(cancellationToken);
}
