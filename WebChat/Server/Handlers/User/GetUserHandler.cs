using AutoMapper;
using MediatR;
using WebChat.Data.Entities.Dtos;
using WebChat.Server.Services;
using WebChat.Shared.Requests.User;
using WebChat.Shared.Result.User;

namespace WebChat.Server.Handlers.User;

public class GetUserHandler : IRequestHandler<GetUserRequest, UserResult>
{
    private readonly IMapper _mapper;
    private readonly UserService _userService;

    public GetUserHandler(IMapper mapper, UserService userService)
    {
        _mapper = mapper;
        _userService = userService;
    }
    
    public async Task<UserResult> Handle(GetUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _userService.GetUserById(request.UserId);
        
        return new UserResult()
        {
            User = _mapper.Map<UserDto>(user)
        };
    }
}