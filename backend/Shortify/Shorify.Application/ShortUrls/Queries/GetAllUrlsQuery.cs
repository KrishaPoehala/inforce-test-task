using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shorify.Application.Common.Dtos;
using Shorify.Domain.Repositories;

namespace Shorify.Application.ShortUrls.Queries;

public class GetAllUrlsQuery:IRequest<IEnumerable<ShortUrlDto>>
{
}

public class GetAllUrlsQueryHandler : IRequestHandler<GetAllUrlsQuery, IEnumerable<ShortUrlDto>>
{
    private readonly IMapper _mapper;
    private readonly IShortUrlsRepository _repository;

    public GetAllUrlsQueryHandler(IMapper mapper, IShortUrlsRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<IEnumerable<ShortUrlDto>> Handle(GetAllUrlsQuery request, CancellationToken cancellationToken)
    {
        var urls = await _repository.GetAll()
                   .ToListAsync(cancellationToken);

        var urlDtos = urls.Select(x => _mapper.Map<ShortUrlDto>(x));
        return urlDtos;
    }
}
