using MediatR;
using WebChat.Shared.Result;
using WebChat.Shared.Result.User;

namespace WebChat.Shared.Requests.User;

public record GetUsersRequest : IRequest<GetUsersResult>
{
    
}