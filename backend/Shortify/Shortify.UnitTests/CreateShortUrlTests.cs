using Moq;
using Shorify.Application.ShortUrls.Commands;

namespace Shortify.UnitTests;

public class CreateShortUrlTests:TestsBase
{
    [Fact]
    public async Task CreateShortUrl_Throws_WhenAlreadExists()
    {
        urlRepoMock.Setup(x => x.ExistByOriginalUrl(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);

        var command = new CreateShortUrlCommand()
        {
            OriginalUrl = "dummy_data",
        };

        var handler = new CreateShortUrlCommandHandler(mapperMock.Object, currentUserMock.Object,
            shortenerMock.Object, unitOfWorkMock.Object, urlRepoMock.Object, userRepoMock.Object);

        await Assert.ThrowsAsync<ArgumentException>(async () => await handler.Handle(command, default));
    }
}
