using Shorify.Domain.Entities;
using System.Security.Claims;

namespace Shorify.Application.Common.Interfaces;

public interface ITokenProvider
{
    string GenerateToken(Domain.Entities.User user);
}
