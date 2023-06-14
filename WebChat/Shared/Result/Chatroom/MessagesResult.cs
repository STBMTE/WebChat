using WebChat.Data.Entities.Dtos;

namespace WebChat.Shared.Result.Chatroom;

public record MessagesResult
{
    public required ICollection<MessageDto> Messages { get; set; }
}