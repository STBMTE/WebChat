using System.Collections;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WebChat.Shared.Requests;
using WebChat.Shared.Requests.Message;

namespace WebChat.Server.Controllers;

public class MessageController : Hub
{
    private readonly IMediator _mediator;
    private readonly IHubContext<MessageController> _hubContext;
    private static List<Tuple<long, string>> _clientProxies = new List<Tuple<long, string>>();

    public MessageController(IMediator mediator, IHubContext<MessageController> hubContext)
    {
        _mediator = mediator;
        _hubContext = hubContext;
    }
    
    public override Task OnDisconnectedAsync(Exception? exception)
    {
        Tuple<long, string> deleted = new Tuple<long, string>(0, null);
        foreach (var proxy in _clientProxies)
        {
            if (proxy.Item2 == Context.ConnectionId)
            {
                deleted = proxy;
            }
        }

        if (!(deleted.Item1 == 0 && deleted.Item2 == null))
        {
            _clientProxies.Remove(deleted);
        }

        return base.OnDisconnectedAsync(exception);
    }

    //Subscribe from Notification
    public async Task SubscribeNotificationHub(long id)
    {
        _clientProxies.Add(new (id, Context.ConnectionId));
        await _hubContext.Clients.Client(Context.ConnectionId).SendAsync("SuccssefullSubscribe");
    }
    
    // POST: api/messages/add
    public async Task CreateMessage(CreateMessageRequest createUserRequest)
    {
        var e = await _mediator.Send(createUserRequest);
        if (e is null)
        {
            await _hubContext.Clients.All.SendAsync("Message Conflict");
        }
        else
        {
            var users = await _mediator.Send(new NotificationRequest
            {
                ChatId = createUserRequest.ChatId
            });
            List<string> clientProxy = new List<string>();
            foreach (var key in _clientProxies)
            {
                if (users.Users.Any(u => u.Id == key.Item1))
                {
                    clientProxy.Add(key.Item2);
                }
            }
            var context = _hubContext.Clients.Clients(clientProxy).SendAsync("NewMessage", e);
            await _hubContext.Clients.Client(Context.ConnectionId).SendAsync("MessageSend", e);
        }
    }
}