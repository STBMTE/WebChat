using WebChat.Data.Entities.Models;

namespace WebChat.Data.Repositories;

public class MessageRepository: Repository<Message>
{
    public MessageRepository(ChatContext dbContext) : base(dbContext) { }
        
    public async ValueTask<Message?> GetMessage(long id) => await GetById(id);
    
    public async ValueTask<Message?> AddMessage(Message message) => await Add(message);
}