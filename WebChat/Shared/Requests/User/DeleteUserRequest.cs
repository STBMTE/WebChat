using MediatR;
using WebChat.Shared.Result;

namespace WebChat.Shared.Requests.User;

public record DeleteUserRequest : IRequest<bool>
{
    public required long UserId { get; init; }
}