using MediatR;
using WebChat.Server.Services;
using WebChat.Shared.Requests.Chatroom;
using WebChat.Shared.Requests.User;

namespace WebChat.Server.Handlers.Chatrooms;

public class DeleteChatroomHandler : IRequestHandler<DeleteChatroomRequest, bool>
{
    private readonly ChatroomService _chatroomService;

    public DeleteChatroomHandler(ChatroomService chatroomService)
    {
        _chatroomService = chatroomService;
    }

    public async Task<bool> Handle(DeleteChatroomRequest request, CancellationToken cancellationToken)
    {
        return await _chatroomService.DeleteChatroom(request.ChatroomId);
    }
}