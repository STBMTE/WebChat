using AutoMapper;
using MediatR;
using WebChat.Data.Entities.Dtos;
using WebChat.Server.Services;
using WebChat.Shared.Requests.Chatroom;
using WebChat.Shared.Result.Chatroom;

namespace WebChat.Server.Handlers.Chatrooms;

public class GetUserChatroomsHandler : IRequestHandler<GetUserChatroomsRequest, GetUserChatroomsResult>
{
    private readonly IMapper _mapper;
    private readonly ChatroomService _chatroomService;

    public GetUserChatroomsHandler(ChatroomService chatroomService, IMapper mapper)
    {
        _chatroomService = chatroomService;
        _mapper = mapper;
    }

    public async Task<GetUserChatroomsResult> Handle(GetUserChatroomsRequest request, CancellationToken cancellationToken)
    {
        var userChatrooms = await _chatroomService.GetUserChatrooms(request.UserId);
        
        return new GetUserChatroomsResult()
        {
            Chatrooms = _mapper.Map<ICollection<ChatroomDto>>(userChatrooms)
        };
    }
}