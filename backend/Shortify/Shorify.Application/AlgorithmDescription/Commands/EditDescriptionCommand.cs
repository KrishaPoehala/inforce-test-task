using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shorify.Application.Common.Dtos;
using Shorify.Application.Common.Interfaces;

namespace Shorify.Application.AlgorithmDescription.Commands;

public class EditDescriptionCommand:IRequest<DescriptionDto>
{
    public string NewDescription { get; set; }
}

public class EditDescriptionCommandHandler : IRequestHandler<EditDescriptionCommand, DescriptionDto>
{
    private readonly IApplicationDbContext _context;
    private readonly ICurrentUserService _currentUserService;
    private readonly IMapper _mapper;
    public EditDescriptionCommandHandler(IApplicationDbContext context, ICurrentUserService currentUserService,
        IMapper mapper)
    {
        _context = context;
        _currentUserService = currentUserService;
        _mapper = mapper;
    }

    public async Task<DescriptionDto> Handle(EditDescriptionCommand request, CancellationToken cancellationToken)
    {
        var desc = await _context.AlgorithmDescriptions.SingleAsync(cancellationToken);
        desc.Description = request.NewDescription;
        desc.LastModifiedById = _currentUserService.Id;
        await _context.SaveChangesAsync(cancellationToken);
        return _mapper.Map<DescriptionDto>(desc);
    }
}
