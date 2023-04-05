using Microsoft.AspNetCore.Mvc;
using Moq;
using Shorify.Application.User.Commands;
using Shorify.Domain.Entities;
using System.Linq.Expressions;

namespace Shortify.UnitTests;

public class AuthTests:TestsBase
{

    [Fact]
    public async Task Login_ReturnsError_WhenUserAlreadyExists()
    {
        userRepoMock.Setup(x => x.GetByOrDefault(It.IsAny<Expression<Func<User, bool>>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((User)null);

        var comand = new LoginUserCommand()
        {
            Email = "sfsdf",
            Password = "password",
        };

        var handler = new LoginUserCommandHandler(tokenMock.Object, userRepoMock.Object);
        var result = await handler.Handle(comand, default);
        Assert.False(result.IsSuccessfull);
        Assert.True(result.AuthErrors.Any());
    }

    [Fact]
    public async Task Login_GetsToken_WhenUserIsNew()
    {
        var testUser = new User()
        {
            Name = "ffff",
            HashedPassword= "AQAAAAIAAYagAAAAEBXCCLTia+8IEy3+cMHQ0F1CvKgmfVS/b025juYqwUE8lTt2ag0U90LPA9BlzEBUZQ==",
            Email = "safasfasf",
        };

        var testToken = "test-token";

        userRepoMock.Setup(x => x.GetByOrDefault(It.IsAny<Expression<Func<User, bool>>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(testUser);

        tokenMock.Setup(x => x.GenerateToken(testUser))
            .Returns(testToken);

        var command = new LoginUserCommand()
        {
            Email = "ffff",
            Password = "string",
        };

        var handler = new LoginUserCommandHandler(tokenMock.Object, userRepoMock.Object);
        var result = await handler.Handle(command, default);
        Assert.Equal(testToken, result.AccessToken);
    }
}
