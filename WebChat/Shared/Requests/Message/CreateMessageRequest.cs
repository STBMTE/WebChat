using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using MediatR;
using Microsoft.VisualBasic;
using WebChat.Data.Entities.Dtos;
using WebChat.Shared.Result.Message;

namespace WebChat.Shared.Requests.Message;

public record CreateMessageRequest : IRequest<MessageResult>
{
    public int AuthorId { get; init; }
    public required int ChatId { get; init; }
    public required string Text { get; init; }
}