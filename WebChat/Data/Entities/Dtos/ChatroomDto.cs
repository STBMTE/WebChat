namespace WebChat.Data.Entities.Dtos;

public class ChatroomDto : BaseDto
{
    public string Name { get; set; }
    public ICollection<MessageDto>? Messages { get; set; } = new List<MessageDto>();
    public ICollection<UserDto>? Users { get; set; } = new List<UserDto>();
}