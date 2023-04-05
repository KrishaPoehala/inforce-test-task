using Shorify.Domain.Entities;
namespace Shortify.Infrastucture.Persistance;

public class ApplicationDbContextInitializer
{
    private readonly ApplicationDbContext _context;

    public ApplicationDbContextInitializer(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task InitializeAsync()
    {
        var users = new List<User>()
        {
            new()
            {
                Id=Guid.NewGuid().ToString(),
                Email = "string2",
                Role = Common.Enums.Roles.Admin,
                //string
                HashedPassword = "AQAAAAIAAYagAAAAEBXCCLTia+8IEy3+cMHQ0F1CvKgmfVS/b025juYqwUE8lTt2ag0U90LPA9BlzEBUZQ==",
                Name="string1",
            }
        };

        var urls = new List<ShortenedUrlInstance>()
        {
            new()
            {
                Id = Guid.NewGuid().ToString(),
                CreatedById = users[0].Id,
                OriginalUrl = "https://google.com",
                ShortenedUrl = "sadf",

            },
            new()
            {
                Id = Guid.NewGuid().ToString(),
                CreatedById = users[0].Id,
                OriginalUrl = "https://fff.com",
                ShortenedUrl = "sadsff",

            },
            new()
            {
                Id = Guid.NewGuid().ToString(),
                CreatedById = users[0].Id,
                OriginalUrl = "https://asdf.com",
                ShortenedUrl = "saasdfdf",

            },
            new()
            {
                Id = Guid.NewGuid().ToString(),
                CreatedById = users[0].Id,
                OriginalUrl = "https://google.com",
                ShortenedUrl = "sadfdfb",
            },
             new()
            {
                Id = Guid.NewGuid().ToString(),
                CreatedById = users[0].Id,
                OriginalUrl = "https://www.youtube.com/watch?v=dQw4w9WgXcQ",
                ShortenedUrl = "try-me",
            },
        };

        if(_context.Users.Any() == false)
        {
            _context.Users.AddRange(users);
            await _context.SaveChangesAsync();
        }

        if(_context.ShortenedUrls.Any() == false)
        {
            _context.ShortenedUrls.AddRange(urls);
            await _context.SaveChangesAsync();
        }

        var description = new AlgorithmDescription()
        {
            Id = Guid.NewGuid().ToString(),
            Description = "This is the  default description",
        };

        if(_context.AlgorithmDescriptions.Any() == false)
        {
            _context.AlgorithmDescriptions.Add(description);
            await _context.SaveChangesAsync();
        }
    }
}
