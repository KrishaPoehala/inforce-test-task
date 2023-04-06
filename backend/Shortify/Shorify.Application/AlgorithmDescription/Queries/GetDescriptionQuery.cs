using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shorify.Application.Common.Dtos;
using Shorify.Application.Common.Interfaces;
using Shorify.Domain.Repositories;

namespace Shorify.Application.AlgorithmDescription.Queries;

public class GetDescriptionQuery:IRequest<DescriptionDto>
{
}

public class GetDescriptionQueryHandler : IRequestHandler<GetDescriptionQuery, DescriptionDto>
{
    private readonly IMapper _mapper;
    private readonly IDescriptionRepository _repository;

    public GetDescriptionQueryHandler(IMapper mapper, IDescriptionRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<DescriptionDto> Handle(GetDescriptionQuery request, CancellationToken cancellationToken)
    {
        var desc = await _repository.Get(cancellationToken);
        return _mapper.Map<DescriptionDto>(desc);
    }
}
