using System;
using API_megaplay.Models;
using API_megaplay.Models.Dtos;
using AutoMapper;

namespace API_megaplay.Mapping;

public class UserProfile : Profile
{

    public UserProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<User, CreateUserDto>().ReverseMap();
        CreateMap<User, UpdateUserDto>().ReverseMap();
    }

}
