namespace WebChat.Data.Entities.Models;

public abstract class BaseModel
{
    public long Id { get; set; }
    public bool IsDeleted { get; set; }
}