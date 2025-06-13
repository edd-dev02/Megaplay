using API_megaplay.Models;
using API_megaplay.Models.Dtos;
using AutoMapper;

namespace API_megaplay.Mapping;

public class MovieProfile : Profile
{
    public MovieProfile()
    {
        CreateMap<Movie, MovieDto>()
            .ForMember(dest => dest.GenreName, opt => opt.MapFrom(src => src.Genre.GenreName))
            .ForMember(dest => dest.SectionName, opt => opt.MapFrom(src => src.Section.SectionName));

        //CreateMap<MovieDto, Movie>();
        CreateMap<Movie, CreateMovieDto>().ReverseMap();
    }
}