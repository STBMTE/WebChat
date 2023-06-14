using WebChat.Data.Entities.Dtos;

namespace WebChat.Shared.Result.User;

public record UserResult
{
    public required UserDto User { get; init; }
}