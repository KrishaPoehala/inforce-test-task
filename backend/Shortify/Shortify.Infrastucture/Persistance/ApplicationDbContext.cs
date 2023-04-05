using Microsoft.EntityFrameworkCore;
using Shorify.Application.Common.Interfaces;
using Shorify.Domain.Entities;
using System.Reflection;

namespace Shortify.Infrastucture.Persistance;

public class ApplicationDbContext:DbContext,IApplicationDbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<ShortenedUrlInstance> ShortenedUrls { get; set; }
    public DbSet<AlgorithmDescription> AlgorithmDescriptions { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        :base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}
