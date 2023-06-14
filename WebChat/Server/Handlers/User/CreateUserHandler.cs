using AutoMapper;
using MediatR;
using WebChat.Data.Entities.Dtos;
using WebChat.Server.Services;
using WebChat.Shared.Requests.User;
using WebChat.Shared.Result.User;

namespace WebChat.Server.Handlers.User;

public class CreateUserHandler : IRequestHandler<CreateUserRequest, UserResult>
{
    private readonly IMapper _mapper;
    private readonly UserService _userService;

    public CreateUserHandler(UserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }
    
    public async Task<UserResult> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _userService.CreateUser(_mapper.Map<Data.Entities.Models.User>(request.User));
        
        return new UserResult()
        {
            User = _mapper.Map<UserDto>(user)
        };
    }
}