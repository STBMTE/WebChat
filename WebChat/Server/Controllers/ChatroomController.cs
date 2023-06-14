using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WebChat.Shared.Requests.Chatroom;

namespace WebChat.Server.Controllers;

public class ChatroomController : Hub
{
    // обновление названия чата)
    
    private readonly IMediator _mediator;
    private readonly IHubContext<ChatroomController> _hubContext;

    public ChatroomController(IMediator mediator, IHubContext<ChatroomController> hubContext)
    {
        _mediator = mediator;
        _hubContext = hubContext;
    }
    
    // POST: api/chatrooms/add
    public async Task CreateChatroom(CreateChatroomRequest createChatroomRequest)
    {
        var e = await _mediator.Send(createChatroomRequest);
        if (e?.Chatroom is null)
        {
            await _hubContext.Clients.All.SendAsync("ChatroomConflicted");
        }
        else
        {
            await _hubContext.Clients.All.SendAsync("CreateChatroom", e);
        }
    }
    
    // GET: api/chatrooms/current/messages
    public async Task GetMessagesInChatroom(GetMessagesInChatroomRequest getMessagesInChatroomRequest)
    {
        var e = await _mediator.Send(getMessagesInChatroomRequest);
        if (e?.Messages is null)
        {
            await _hubContext.Clients.All.SendAsync("MessagesNotFound", getMessagesInChatroomRequest);
        }
        else
        {
            await _hubContext.Clients.All.SendAsync("GetMessagesInChatroom", e);
        }
    }
    
    // GET: api/chatrooms/current/user
    public async Task GetUserChatrooms([FromQuery] GetUserChatroomsRequest getUserChatroomsRequest)
    {
        var e = await _mediator.Send(getUserChatroomsRequest);
        if (e?.Chatrooms is null)
        {
            await _hubContext.Clients.All.SendAsync("UserChatroomsNotFound", getUserChatroomsRequest);
        }
        else
        {
            await _hubContext.Clients.All.SendAsync("GetUserChatrooms", e);
        }   
    }
    
    // POST: api/chatrooms/current/change-name
    public async Task ChangeNicknameUser(UpdateChatroomRequest updateUserRequest)
    {
        var e = await _mediator.Send(updateUserRequest);
        if (e?.Chatroom is null)
        {
            await _hubContext.Clients.All.SendAsync("ChangeNicknameUserDenied", updateUserRequest);
        }
        else
        {
            await _hubContext.Clients.All.SendAsync("ChangeNicknameUser", e);
        }
    }
    
    // DELETE: api/chatrooms/current
    public async Task DeleteUser([FromQuery] DeleteChatroomRequest deleteUserRequest)
    {
        var e = await _mediator.Send(deleteUserRequest);
        if (!e)
        {
            await _hubContext.Clients.All.SendAsync("DeleteUserDenied", deleteUserRequest);
        }
        else
        {
            await _hubContext.Clients.All.SendAsync("DeleteUser", e);
        }
    }
}