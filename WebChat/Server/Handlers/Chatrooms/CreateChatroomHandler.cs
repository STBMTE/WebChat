using AutoMapper;
using MediatR;
using WebChat.Data.Entities.Dtos;
using WebChat.Server.Services;
using WebChat.Shared.Requests.Chatroom;
using WebChat.Shared.Result.Chatroom;

namespace WebChat.Server.Handlers.Chatrooms;

public class CreateChatroomHandler : IRequestHandler<CreateChatroomRequest, ChatroomResult>
{
    private readonly IMapper _mapper;
    private readonly ChatroomService _chatroomService;

    public CreateChatroomHandler(ChatroomService chatroomService, IMapper mapper)
    {
        _chatroomService = chatroomService;
        _mapper = mapper;
    }

    public async Task<ChatroomResult> Handle(CreateChatroomRequest request, CancellationToken cancellationToken)
    {
        var chatroom = await _chatroomService.CreateChatroom(request.Name, request.UsersId);
        
        return new ChatroomResult()
        {
            Chatroom = _mapper.Map<ChatroomDto>(chatroom)
        };
    }
}