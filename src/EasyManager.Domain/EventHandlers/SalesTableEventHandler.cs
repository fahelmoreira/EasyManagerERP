using System.Threading;
using System.Threading.Tasks;
using EasyManager.Domain.Events;
using MediatR;

namespace EasyManager.Domain.EventHandlers
{
    public class SalesTableEventHandler :
        INotificationHandler<SalesTableItemRegisteredEvent>,
        INotificationHandler<SalesTableItemRemovedEvent>,
        INotificationHandler<SalesTableItemUpdatedEvent>
    {
        public Task Handle(SalesTableItemRegisteredEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(SalesTableItemRemovedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(SalesTableItemUpdatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}