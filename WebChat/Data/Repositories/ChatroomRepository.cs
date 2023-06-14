using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using WebChat.Data.Entities.Dtos;
using WebChat.Data.Entities.Models;

namespace WebChat.Data.Repositories;

public class ChatroomRepository: Repository<Chatroom>
{
    public ChatroomRepository(ChatContext dbContext) : base(dbContext) { }
        
    public async ValueTask<Chatroom?> GetChatroom(long id) => await GetById(id);

    private async Task<Chatroom?> GetChatroomWithInclude(long id)
    {
       return await Set
            .Include(c => c.Messages.Where(m => !m.IsDeleted))
            .Include(c => c.Users.Where(user => user != null && !user.IsDeleted))
            .SingleOrDefaultAsync(c => c.Id == id && !c.IsDeleted);
    }
    
    public async Task<IReadOnlyCollection<Message?>?> GetMessagesInChatroom(long id)
    {
        var includeChatroom = await GetChatroomWithInclude(id);
        return includeChatroom?.Messages.ToList();
    }
    
    public async Task<List<Chatroom>> GetUserChatrooms(long userId)
    {
        return await GetAll()
            .Include(c => c.Users)
            .Where(chat => chat.Users.Any(u => u != null && u.Id == userId))
            .ToListAsync();;
    }
    
    public async ValueTask<Chatroom?> AddChatroom(Chatroom chatroom) => await Add(chatroom);
    
    public async ValueTask<Chatroom?> UpdateChatroom(Chatroom chatroom) => await Update(chatroom);

    public async ValueTask<bool> DeleteChatroom(long id) => await Delete(id);
} 