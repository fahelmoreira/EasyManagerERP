using System.Threading;
using System.Threading.Tasks;
using EasyManager.Domain.Events;
using MediatR;

namespace EasyManager.Domain.EventHandlers
{
    public class OrderEventHandler :
        INotificationHandler<OrderRegisteredEvent>,
        INotificationHandler<OrderRemovedEvent>,
        INotificationHandler<OrderUpdatedEvent>
    {
        public Task Handle(OrderRegisteredEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(OrderRemovedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(OrderUpdatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}