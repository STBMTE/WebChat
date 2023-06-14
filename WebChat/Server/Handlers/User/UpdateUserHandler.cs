using AutoMapper;
using MediatR;
using WebChat.Data.Entities.Dtos;
using WebChat.Server.Services;
using WebChat.Shared.Requests.User;
using WebChat.Shared.Result.User;

namespace WebChat.Server.Handlers.User;

public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UserResult?>
{
    private readonly IMapper _mapper;
    private readonly UserService _userService;

    public UpdateUserHandler(UserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }
    
    public async Task<UserResult?> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var user = _userService.GetUserById(request.UserId).Result;
        if (user is null)
            return null;
        
        user.Nickname = request.Nickname;
        var updateUser = await _userService.UpdateUser(user);
        
        return new UserResult()
        {
            User = _mapper.Map<UserDto>(updateUser)
        };
    }
}