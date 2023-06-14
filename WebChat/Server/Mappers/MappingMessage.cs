using AutoMapper;
using WebChat.Data.Entities.Dtos;
using WebChat.Data.Entities.Models;

namespace WebChat.Server.Mappers;

public class MappingMessage: Profile
{
    public MappingMessage()
    {
        CreateMap<Message, MessageDto>().ReverseMap();
    }
}