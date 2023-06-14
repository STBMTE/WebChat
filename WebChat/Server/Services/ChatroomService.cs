using WebChat.Data.Entities.Models;
using WebChat.Data.Repositories;

namespace WebChat.Server.Services;

public class ChatroomService : IService
{
    private readonly ChatroomRepository _chatroomRepository;
    private readonly UserRepository _userRepository;

    public ChatroomService(ChatroomRepository chatroomRepository, UserRepository userRepository)
    {
        _chatroomRepository = chatroomRepository;
        _userRepository = userRepository;
    }
    
    public async Task<Chatroom?> CreateChatroom(string name, long[] usersId)
    {
        var users = usersId.Select(id => _userRepository.GetUser(id).Result).ToList();

        if (users.Count > 0 && users.Any(u => u is not null))
        {
            var chatroom = new Chatroom()
            {
                Name = name,
                Messages = new List<Message>(),
                Users = users
            };
            
            return await _chatroomRepository.AddChatroom(chatroom);
        }
        
        return null;
    }
    
    public async Task<IReadOnlyCollection<Message?>?> GetMessagesInChatroom(long chatroomId)
    {
        if (_chatroomRepository.GetChatroom(chatroomId).Result is not null)
        {
            return await _chatroomRepository.GetMessagesInChatroom(chatroomId);
        }
        
        return null;
    }
    
    public async Task<IReadOnlyCollection<Chatroom?>?> GetUserChatrooms(long userId)
    {
        if (_userRepository.GetUser(userId).Result is not null)
        {
            return await _chatroomRepository.GetUserChatrooms(userId);
        }
        
        return null;
    }

    public async Task<IReadOnlyCollection<User?>?> GetUsersInChatroom(long chatroomId)
    {
        var e = await _chatroomRepository.GetChatroom(chatroomId);
        return e?.Users.ToList();
    }

    public async Task<Chatroom?> UpdateChatroom(Chatroom chatroom)
    {
        return await _chatroomRepository.UpdateChatroom(chatroom);
    }
    
    public async Task<Chatroom?> GetChatroomById(long chatroomId)
    {
        return await _chatroomRepository.GetChatroom(chatroomId);
    }

    public async Task<bool> DeleteChatroom(long chatroomId)
    {
        return await _chatroomRepository.DeleteChatroom(chatroomId);
    }
}