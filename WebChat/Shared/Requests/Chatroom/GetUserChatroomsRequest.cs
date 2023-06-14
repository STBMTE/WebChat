using MediatR;
using WebChat.Shared.Result;
using WebChat.Shared.Result.Chatroom;

namespace WebChat.Shared.Requests.Chatroom;

public record GetUserChatroomsRequest : IRequest<GetUserChatroomsResult>
{
    public required long UserId { get; init; }
}