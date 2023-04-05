using MediatR;
using Microsoft.AspNetCore.Identity;
using Shorify.Application.Common.Dtos;
using Shorify.Application.Common.Interfaces;
using Shorify.Domain.Repositories;

namespace Shorify.Application.User.Commands;

public class LoginUserCommand:IRequest<AuthResponseDto>
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, AuthResponseDto>
{
    private readonly ITokenProvider _tokenProvider;
    private readonly IUserRepository _repository;

    public LoginUserCommandHandler(ITokenProvider tokenProvider, IUserRepository repository)
    {
        _tokenProvider = tokenProvider;
        _repository = repository;
    }

    public async Task<AuthResponseDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetByOrDefault(x => x.Email == request.Email, cancellationToken);
        if(user is null)
        {
            return new(new[] { "User with such email does not exist" });
        }

        var hasher = new PasswordHasher<Domain.Entities.User>();
        var verificationResult = hasher.VerifyHashedPassword(user, user.HashedPassword, request.Password);
        if(verificationResult == PasswordVerificationResult.Failed)
        {
            return new(new[] { "Wrong password" });
        }

        var token = _tokenProvider.GenerateToken(user);
        return new(token);
    }
}
