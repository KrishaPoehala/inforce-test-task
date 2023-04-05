using AutoMapper;
using Shorify.Application.Common.Dtos;
using Shorify.Application.User.Commands;

namespace Shorify.Application.Common.Mapping;

public class AuthMappingProfile:Profile
{
    public AuthMappingProfile()
    {
        CreateMap<Domain.Entities.User, RegisterUserCommand>().ReverseMap();
        CreateMap<RegisterUserCommand, Domain.Entities.User>();
        CreateMap<Domain.Entities.User, UserDto>().ReverseMap();
    }
}
