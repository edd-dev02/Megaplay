using System;
using API_megaplay.Models;
using API_megaplay.Models.Dtos;
using AutoMapper;

namespace API_megaplay.Mapping;

public class GenreProfile : Profile
{

    public GenreProfile()
    {
        CreateMap<Genre, GenreDto>().ReverseMap();
        CreateMap<Genre, CreateGenreDto>().ReverseMap();
    }

}
