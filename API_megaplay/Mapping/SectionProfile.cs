using System;
using API_megaplay.Models;
using API_megaplay.Models.Dtos;
using AutoMapper;

namespace API_megaplay.Mapping;

public class SectionProfile : Profile
{
    public SectionProfile()
    {
        CreateMap<Section, SectionDto>().ReverseMap();
        CreateMap<Section, CreateSectionDto>().ReverseMap();
    }
}
