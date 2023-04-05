using AutoMapper;
using MediatR;
using Shorify.Application.Common.Dtos;
using Shorify.Application.Common.Interfaces;
using Shorify.Domain.Entities;
using Shorify.Domain.Repositories;
using Shorify.Domain.UnitOfWork;

namespace Shorify.Application.ShortUrls.Commands;

public class CreateShortUrlCommand:IRequest<ShortUrlDto>
{
    public string OriginalUrl { get; set; } = null!;
}

public class CreateShortUrlCommandHandler : IRequestHandler<CreateShortUrlCommand, ShortUrlDto>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IShortUrlsRepository _repository;
    private readonly ICurrentUserService _currentUserService;
    private readonly IUrlShortener _shortener;
    private readonly IUserRepository _userRepository;

    public CreateShortUrlCommandHandler(IMapper mapper, ICurrentUserService currentUserService,
        IUrlShortener shortener, IUnitOfWork unitOfWork, IShortUrlsRepository repository, IUserRepository userRepository)
    {
        _mapper = mapper;
        _currentUserService = currentUserService;
        _shortener = shortener;
        _unitOfWork = unitOfWork;
        _repository = repository;
        _userRepository = userRepository;
    }

    public async Task<ShortUrlDto> Handle(CreateShortUrlCommand request, CancellationToken cancellationToken)
    {
        var alreadExists = await _repository.ExistByOriginalUrl(request.OriginalUrl, cancellationToken);
        if (alreadExists)
        {
            throw new ArgumentException("Such a url alread exists");
        }

        var id = Guid.NewGuid();
        var bytes = id.ToByteArray();
        var uniqueNumber = BitConverter.ToInt64(bytes, 0);
        var shortUrl = _shortener.GenerateShortenedUrl(uniqueNumber);
        var newShortUrl = new ShortenedUrlInstance()
        {
            Id = id.ToString(),
            CreatedById = _currentUserService.Id,
            OriginalUrl = request.OriginalUrl,
            ShortenedUrl = shortUrl,
        };

        _repository.Add(newShortUrl);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var createdBy = await _userRepository.GetByOrDefault(x => x.Id == _currentUserService.Id,cancellationToken);
        newShortUrl.CreatedBy = createdBy!;
        return _mapper.Map<ShortUrlDto>(newShortUrl);
    }
}
