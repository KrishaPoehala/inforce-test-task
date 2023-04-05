using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shorify.Domain.Entities;

namespace Shortify.Infrastucture.Persistance.Configuration;

public class AlgorithmDescriptionConfiguration : IEntityTypeConfiguration<AlgorithmDescription>
{
    public void Configure(EntityTypeBuilder<AlgorithmDescription> builder)
    {
        builder.HasOne(x => x.LastModifiedBy).WithOne();
    }
}
