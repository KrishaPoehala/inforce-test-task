using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shorify.Domain.Entities;

namespace Shortify.Infrastucture.Persistance.Configuration;

public class ShortenedUrlInstanceConfiguration : IEntityTypeConfiguration<ShortenedUrlInstance>
{
    public void Configure(EntityTypeBuilder<ShortenedUrlInstance> builder)
    {
        builder
            .HasIndex(x => x.ShortenedUrl)
            .IsUnique(true);

        builder
            .HasOne(x => x.CreatedBy)
            .WithMany(x => x.CreatedUrls)
            .HasForeignKey(x => x.CreatedById);

        

    }
}
