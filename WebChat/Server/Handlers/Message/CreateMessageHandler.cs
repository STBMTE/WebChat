using AutoMapper;
using MediatR;
using WebChat.Data.Entities.Dtos;
using WebChat.Server.Services;
using WebChat.Shared.Requests.Message;
using WebChat.Shared.Result.Message;

namespace WebChat.Server.Handlers.Message;

public class CreateMessageHandler : IRequestHandler<CreateMessageRequest, MessageResult>
{
    private readonly IMapper _mapper;
    private readonly MessageService _messageService;

    public CreateMessageHandler(MessageService messageService, IMapper mapper)
    {
        _messageService = messageService;
        _mapper = mapper;
    }
    
    public async Task<MessageResult> Handle(CreateMessageRequest request, CancellationToken cancellationToken)
    {
        var message = await _messageService.CreateMessage(request.AuthorId, request.ChatId, request.Text);
        
        return new MessageResult()
        {
            Message = _mapper.Map<MessageDto>(message)
        };
    }
}