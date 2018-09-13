using System.Threading;
using System.Threading.Tasks;
using EasyManager.Domain.Events;
using MediatR;

namespace EasyManager.Domain.EventHandlers
{
    public class BankAccountEventHandler :
        INotificationHandler<BankAccountRegisteredEvent>,
        INotificationHandler<BankAccountRemovedEvent>,
        INotificationHandler<BankAccountUpdatedEvent>
    {
        public Task Handle(BankAccountRegisteredEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(BankAccountRemovedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(BankAccountUpdatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}