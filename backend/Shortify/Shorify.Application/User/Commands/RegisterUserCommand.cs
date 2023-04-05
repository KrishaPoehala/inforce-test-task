using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Shorify.Application.Common.Dtos;
using Shorify.Application.Common.Interfaces;
using Shorify.Domain.Repositories;
using Shorify.Domain.UnitOfWork;

namespace Shorify.Application.User.Commands;

public class RegisterUserCommand: IRequest<AuthResponseDto>
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, AuthResponseDto>
{
    private readonly ITokenProvider _tokenProvider;
    private readonly IMapper _mapper;
    private readonly IUserRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    public RegisterUserCommandHandler(ITokenProvider tokenProvider, IMapper mapper, IUserRepository repository, IUnitOfWork unitOfWork)
    {
        _tokenProvider = tokenProvider;
        _mapper = mapper;
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<AuthResponseDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var alreadyExists = await _repository.ExistsByEmail(request.Email, cancellationToken);
        if (alreadyExists)
        {
            return new(new[] { "User with such an email alread exists" });
        }

        var hasher = new PasswordHasher<Domain.Entities.User>();
        var user = _mapper.Map<Domain.Entities.User>(request);
        user.Id = Guid.NewGuid().ToString();
        user.HashedPassword = hasher.HashPassword(user, request.Password);
        _repository.Add(user);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        var accessToken = _tokenProvider.GenerateToken(user);
        return new(accessToken);
    }
}
