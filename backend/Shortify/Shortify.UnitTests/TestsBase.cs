using AutoMapper;
using Moq;
using Shorify.Application.Common.Interfaces;
using Shorify.Domain.Repositories;
using Shorify.Domain.UnitOfWork;

namespace Shortify.UnitTests;

public abstract class TestsBase
{
    protected readonly Mock<IUserRepository> userRepoMock = new();
    protected readonly Mock<IShortUrlsRepository> urlRepoMock = new();
    protected readonly Mock<IMapper> mapperMock = new();
    protected readonly Mock<IUnitOfWork> unitOfWorkMock = new();
    protected readonly Mock<ICurrentUserService> currentUserMock = new();
    protected readonly Mock<IUrlShortener> shortenerMock = new();
    protected readonly Mock<ITokenProvider> tokenMock = new();
}
