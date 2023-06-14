using WebChat.Data.Entities.Models;
using WebChat.Data.Repositories;

namespace WebChat.Server.Services;

public class MessageService : IService
{
    private readonly MessageRepository _messageRepository;
    private readonly ChatroomRepository _chatroomRepository;
    private readonly UserRepository _userRepository;

    public MessageService(MessageRepository messageRepository, ChatroomRepository chatroomRepository, UserRepository userRepository)
    {
        _messageRepository = messageRepository;
        _chatroomRepository = chatroomRepository;
        _userRepository = userRepository;
    }
    
    public async Task<Message?> CreateMessage(long authorId, long chatId, string text)
    {
        var chatroom = _chatroomRepository.GetChatroom(chatId).Result;
        var user = _userRepository.GetUser(authorId).Result;

        if (chatroom is not null && user is not null)
        {
            var message = new Message
            {
                MessageText = text,
                User = user,
                ChatroomId = chatroom.Id
            };

            return await _messageRepository.AddMessage(message);
        }
        
        return null;
    }
}