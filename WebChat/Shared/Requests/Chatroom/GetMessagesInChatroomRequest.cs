using MediatR;
using WebChat.Data.Entities.Dtos;
using WebChat.Shared.Result.Chatroom;

namespace WebChat.Shared.Requests.Chatroom;

public record GetMessagesInChatroomRequest : IRequest<MessagesResult>
{
    public required long ChatroomId { get; init; }
}