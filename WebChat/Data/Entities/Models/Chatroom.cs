namespace WebChat.Data.Entities.Models;

public class Chatroom : BaseModel
{
    public string Name { get; set; }
    public ICollection<Message> Messages { get; set; } = new List<Message>();
    public ICollection<User?> Users { get; set; } = new List<User?>();
}