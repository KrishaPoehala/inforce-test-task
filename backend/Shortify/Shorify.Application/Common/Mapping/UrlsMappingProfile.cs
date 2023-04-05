using AutoMapper;
using Shorify.Application.Common.Dtos;
using Shorify.Application.ShortUrls.Commands;
using Shorify.Domain.Entities;

namespace Shorify.Application.Common.Mapping;

public class UrlsMappingProfile:Profile
{
    public UrlsMappingProfile()
    {
        CreateMap<ShortUrlDto, ShortenedUrlInstance>().ReverseMap();
        CreateMap<CreateShortUrlCommand, ShortenedUrlInstance>().ReverseMap();
        CreateMap<Domain.Entities.AlgorithmDescription?, DescriptionDto>().ReverseMap();
    }
}
