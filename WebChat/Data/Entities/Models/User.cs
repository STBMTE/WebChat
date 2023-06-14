namespace WebChat.Data.Entities.Models;

public class User : BaseModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Nickname { get; set; }
}