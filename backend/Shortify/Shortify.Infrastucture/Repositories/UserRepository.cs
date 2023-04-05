using Microsoft.EntityFrameworkCore;
using Shorify.Application.Common.Interfaces;
using Shorify.Domain.Entities;
using Shorify.Domain.Repositories;
using System.Linq.Expressions;

namespace Shortify.Infrastucture.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IApplicationDbContext _context;

    public UserRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    public void Add(User user) => _context.Users.Add(user);

    public async Task<bool> ExistsByEmail(string email, CancellationToken cancellationToken) => 
        await _context.Users.AnyAsync(x => x.Email == email,cancellationToken);

    public async Task<User?> GetByOrDefault(Expression<Func<User, bool>> predicate, CancellationToken cancellationToken) =>
        await _context.Users.FirstOrDefaultAsync(predicate, cancellationToken);
}
