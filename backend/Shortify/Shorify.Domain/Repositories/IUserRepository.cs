using Shorify.Domain.Entities;
using System.Linq.Expressions;

namespace Shorify.Domain.Repositories;

public interface IUserRepository
{
    Task<User?> GetByOrDefault(Expression<Func<User,bool>> predicate, CancellationToken cancellationToken);
    Task<bool> ExistsByEmail(string email, CancellationToken cancellationToken);
    void Add(User user);
}
