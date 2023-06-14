using AutoMapper;
using WebChat.Data.Entities.Dtos;
using WebChat.Data.Entities.Models;

namespace WebChat.Server.Mappers;

public class MappingChatroom : Profile
{
    public MappingChatroom()
    {
        CreateMap<Chatroom, ChatroomDto>().ReverseMap();
    }
}