using System.Threading;
using System.Threading.Tasks;
using EasyManager.Domain.Events;
using MediatR;

namespace EasyManager.Domain.EventHandlers
{
    public class PurchaseEventHandler :
        INotificationHandler<PurchaseRegisteredEvent>,
        INotificationHandler<PurchaseRemovedEvent>,
        INotificationHandler<PurchaseUpdatedEvent>
    {
        public Task Handle(PurchaseRegisteredEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(PurchaseRemovedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(PurchaseUpdatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}