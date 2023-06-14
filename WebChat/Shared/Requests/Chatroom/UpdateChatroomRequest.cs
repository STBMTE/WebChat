using MediatR;
using WebChat.Shared.Result.Chatroom;

namespace WebChat.Shared.Requests.Chatroom;

public record UpdateChatroomRequest : IRequest<ChatroomResult>
{
    public required long ChatroomId { get; init; }
    public required string Name { get; init; }
}