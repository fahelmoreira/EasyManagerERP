using System.Threading;
using System.Threading.Tasks;
using EasyManager.Domain.Events;
using MediatR;

namespace EasyManager.Domain.EventHandlers
{
    public class FinancialEventHandler :
        INotificationHandler<FinancialRegisteredEvent>,
        INotificationHandler<FinancialRemovedEvent>,
        INotificationHandler<FinancialUpdatedEvent>
    {
        public Task Handle(FinancialRegisteredEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(FinancialRemovedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(FinancialUpdatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}