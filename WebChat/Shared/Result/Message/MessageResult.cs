using WebChat.Data.Entities.Dtos;

namespace WebChat.Shared.Result.Message;

public record MessageResult
{
    public required MessageDto Message { get; init; }
}