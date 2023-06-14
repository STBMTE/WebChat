namespace WebChat.Data.Entities.Dtos;

public class MessageDto: BaseDto
{
    public string MessageText { get; set; }
    public UserDto User { get; set; }
    public long ChatroomId { get; set; }
}