using AutoMapper;
using MediatR;
using WebChat.Data.Entities.Dtos;
using WebChat.Server.Services;
using WebChat.Shared.Requests.Chatroom;
using WebChat.Shared.Requests.User;
using WebChat.Shared.Result.Chatroom;
using WebChat.Shared.Result.User;

namespace WebChat.Server.Handlers.Chatrooms;

public class UpdateChatroomHandler  : IRequestHandler<UpdateChatroomRequest, ChatroomResult?>
{
    private readonly IMapper _mapper;
    private readonly ChatroomService _chatroomService;

    public UpdateChatroomHandler(ChatroomService chatroomService, IMapper mapper)
    {
        _chatroomService = chatroomService;
        _mapper = mapper;
    }
    
    public async Task<ChatroomResult?> Handle(UpdateChatroomRequest request, CancellationToken cancellationToken)
    {
        var user = _chatroomService.GetChatroomById(request.ChatroomId).Result;
        if (user is null)
            return null;
        
        user.Name = request.Name;
        var updateChatroom = await _chatroomService.UpdateChatroom(user);
        
        return new ChatroomResult()
        {
            Chatroom = _mapper.Map<ChatroomDto>(updateChatroom)
        };
    }
}