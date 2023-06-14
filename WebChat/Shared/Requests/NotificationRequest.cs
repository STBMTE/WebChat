using MediatR;
using WebChat.Shared.Result;

namespace WebChat.Shared.Requests;

public record NotificationRequest : IRequest<NotificationResult>
{
    public required long ChatId { get; set; }
}