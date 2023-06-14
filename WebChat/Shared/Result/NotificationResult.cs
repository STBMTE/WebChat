using WebChat.Data.Entities.Dtos;

namespace WebChat.Shared.Result;

public class NotificationResult
{
    public required ICollection<UserDto> Users { get; set; }
}