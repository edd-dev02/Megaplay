using System;
using API_megaplay.Models;
using API_megaplay.Models.Dtos;
using AutoMapper;

namespace API_megaplay.Mapping;

public class FavoritesProfile : Profile
{

    public FavoritesProfile()
    {
        CreateMap<Favorites, FavoritesDto>().ReverseMap();
    }

}
