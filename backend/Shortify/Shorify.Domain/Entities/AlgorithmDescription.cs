using Shorify.Domain.Common;

namespace Shorify.Domain.Entities;

public class AlgorithmDescription:BaseEntity
{
    public string Description { get; set; }
    public string? LastModifiedById { get; set; }
    public User? LastModifiedBy { get; set; }
}
