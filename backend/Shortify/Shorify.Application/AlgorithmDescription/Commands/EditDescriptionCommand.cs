using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shorify.Application.Common.Dtos;
using Shorify.Application.Common.Interfaces;
using Shorify.Domain.Repositories;
using Shorify.Domain.UnitOfWork;

namespace Shorify.Application.AlgorithmDescription.Commands;

public class EditDescriptionCommand:IRequest<DescriptionDto>
{
    public string NewDescription { get; set; }
}

public class EditDescriptionCommandHandler : IRequestHandler<EditDescriptionCommand, DescriptionDto>
{
    private readonly ICurrentUserService _currentUserService;
    private readonly IMapper _mapper;
    private readonly IDescriptionRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    public EditDescriptionCommandHandler(ICurrentUserService currentUserService, IMapper mapper,
        IDescriptionRepository repository, IUnitOfWork unitOfWork)
    {
        _currentUserService = currentUserService;
        _mapper = mapper;
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<DescriptionDto> Handle(EditDescriptionCommand request, CancellationToken cancellationToken)
    {
        var desc = await _repository.Get(cancellationToken);
        desc.Description = request.NewDescription;
        desc.LastModifiedById = _currentUserService.Id;
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return _mapper.Map<DescriptionDto>(desc);
    }
}
