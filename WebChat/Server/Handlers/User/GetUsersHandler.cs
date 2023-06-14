using AutoMapper;
using MediatR;
using WebChat.Data.Entities.Dtos;
using WebChat.Server.Services;
using WebChat.Shared.Requests.User;
using WebChat.Shared.Result.User;

namespace WebChat.Server.Handlers.User;

public class GetUsersHandler : IRequestHandler<GetUsersRequest, GetUsersResult>
{
    private readonly IMapper _mapper;
    private readonly UserService _userService;

    public GetUsersHandler(IMapper mapper, UserService userService)
    {
        _mapper = mapper;
        _userService = userService;
    }
    
    public async Task<GetUsersResult> Handle(GetUsersRequest request, CancellationToken cancellationToken)
    {
        var users = await _userService.GetAllUser();
        
        return new GetUsersResult()
        {
            Users = _mapper.Map<ICollection<UserDto>>(users)
        };
    }
}