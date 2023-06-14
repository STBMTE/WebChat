using AutoMapper;
using WebChat.Data.Entities.Dtos;
using WebChat.Data.Entities.Models;

namespace WebChat.Server.Mappers;

public class MappingUser: Profile
{
    public MappingUser()
    {
        CreateMap<User, UserDto>().ReverseMap();
    }
}