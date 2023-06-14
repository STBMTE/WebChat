using MediatR;
using WebChat.Data.Entities.Dtos;
using WebChat.Shared.Result.Chatroom;

namespace WebChat.Shared.Requests.Chatroom;

public record CreateChatroomRequest : IRequest<ChatroomResult>
{
    public required string Name { get; set; }
    public required long[] UsersId { get; set; }
}