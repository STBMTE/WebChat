using WebChat.Data.Entities.Dtos;

namespace WebChat.Shared.Result.Chatroom;

public record ChatroomResult
{
    public required ChatroomDto Chatroom { get; init; }
}