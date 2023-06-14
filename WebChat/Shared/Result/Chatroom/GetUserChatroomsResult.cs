using WebChat.Data.Entities.Dtos;

namespace WebChat.Shared.Result.Chatroom;

public record GetUserChatroomsResult
{
    public required ICollection<ChatroomDto> Chatrooms { get; init; }
}