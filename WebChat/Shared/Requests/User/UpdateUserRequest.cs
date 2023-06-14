using MediatR;
using WebChat.Shared.Result;
using WebChat.Shared.Result.User;

namespace WebChat.Shared.Requests.User;

public record UpdateUserRequest : IRequest<UserResult>
{
    public required long UserId { get; init; }
    public required string Nickname { get; init; }
}