namespace WebChat.Data.Entities.Dtos;

public class UserDto : BaseDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Nickname { get; set; }
}