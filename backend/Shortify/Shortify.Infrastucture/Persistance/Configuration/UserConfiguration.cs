using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shorify.Domain.Entities;
using Shortify.Common.Enums;

namespace Shortify.Infrastucture.Persistance.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.Role)
            .HasDefaultValue(Roles.Ordinary);
    }
}
