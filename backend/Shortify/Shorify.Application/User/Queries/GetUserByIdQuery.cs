using AutoMapper;
using MediatR;
using Shorify.Application.Common.Dtos;
using Shorify.Domain.Repositories;

namespace Shorify.Application.User.Queries;

public class GetUserByIdQuery:IRequest<UserDto>
{
    public string Id { get; set; } = null!;
}

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;

    public GetUserByIdQueryHandler(IUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetByOrDefault(x => x.Id == request.Id, cancellationToken);
        var userDto = _mapper.Map<UserDto>(user);
        return userDto;
    }
}
