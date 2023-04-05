using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shorify.Application.Common.Dtos;
using Shorify.Application.Common.Interfaces;

namespace Shorify.Application.AlgorithmDescription.Queries;

public class GetDescriptionQuery:IRequest<DescriptionDto>
{
}

public class GetDescriptionQueryHandler : IRequestHandler<GetDescriptionQuery, DescriptionDto>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;

    public GetDescriptionQueryHandler(IMapper mapper, IApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<DescriptionDto> Handle(GetDescriptionQuery request, CancellationToken cancellationToken)
    {
        var desc = await _context.AlgorithmDescriptions.SingleAsync(cancellationToken);
        return _mapper.Map<DescriptionDto>(desc);
        
    }
}
