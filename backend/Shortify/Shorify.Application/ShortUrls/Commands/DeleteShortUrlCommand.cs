using MediatR;
using Shorify.Domain.Repositories;
using Shorify.Domain.UnitOfWork;

namespace Shorify.Application.ShortUrls.Commands;

public class DeleteShortUrlCommand:IRequest
{
    public string ShortUrlId { get; set; } = null!;
}

public class DeleteShortUrlCommandHandler : IRequestHandler<DeleteShortUrlCommand>
{
    private readonly IShortUrlsRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteShortUrlCommandHandler(IShortUrlsRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteShortUrlCommand request, CancellationToken cancellationToken)
    {
        var urlToDelete = await _repository.GetById(request.ShortUrlId, cancellationToken);
        _repository.Remove(urlToDelete);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
