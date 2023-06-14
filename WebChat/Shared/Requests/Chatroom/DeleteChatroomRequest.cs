using MediatR;

namespace WebChat.Shared.Requests.Chatroom;

public record DeleteChatroomRequest : IRequest<bool>
{
    public required long ChatroomId { get; set; }
}