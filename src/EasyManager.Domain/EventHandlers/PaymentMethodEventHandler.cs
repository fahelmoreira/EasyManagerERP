using System.Threading;
using System.Threading.Tasks;
using EasyManager.Domain.Events;
using MediatR;

namespace EasyManager.Domain.EventHandlers
{
    public class PaymentMethodEventHandler :
        INotificationHandler<PaymentMethodRegisteredEvent>,
        INotificationHandler<PaymentMethodRemovedEvent>,
        INotificationHandler<PaymentMethodUpdatedEvent>
    {
        public Task Handle(PaymentMethodRegisteredEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(PaymentMethodRemovedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(PaymentMethodUpdatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}