using MediatR;

namespace FvckAds.StoreApi.Application.Messages.Commands.Handlers;

public class StoreMessageCommandHandler : IRequestHandler<StoreMessageCommand>
{
    public Task Handle(StoreMessageCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}