using Shorify.Domain.Entities;

namespace Shorify.Domain.Repositories;

public interface IDescriptionRepository
{
    Task<AlgorithmDescription> Get(CancellationToken cancellationToken);
}
