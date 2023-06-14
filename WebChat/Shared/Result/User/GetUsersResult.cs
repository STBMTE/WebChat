using WebChat.Data.Entities.Dtos;

namespace WebChat.Shared.Result.User;

public record GetUsersResult
{
    public required ICollection<UserDto> Users { get; set; }
}