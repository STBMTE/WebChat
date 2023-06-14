using AutoMapper;
using MediatR;
using WebChat.Data.Entities.Dtos;
using WebChat.Server.Services;
using WebChat.Shared.Requests;
using WebChat.Shared.Requests.Chatroom;
using WebChat.Shared.Result;
using WebChat.Shared.Result.Chatroom;
using WebChat.Shared.Result.Message;

namespace WebChat.Server.Handlers;

public class NotificationHandler : IRequestHandler<NotificationRequest, NotificationResult>
{
    private readonly IMapper _mapper;
    private readonly ChatroomService _chatroomService;

    public NotificationHandler(ChatroomService chatroomService, IMapper mapper)
    {
        _chatroomService = chatroomService;
        _mapper = mapper;
    }
    
    public async Task<NotificationResult> Handle(NotificationRequest request, CancellationToken cancellationToken)
    {
        var users = await _chatroomService.GetUsersInChatroom(request.ChatId);
        
        return new NotificationResult()
        {
            Users = _mapper.Map<ICollection<UserDto>>(users)
        };
    }
}