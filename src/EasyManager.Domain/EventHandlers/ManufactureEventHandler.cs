using System.Threading;
using System.Threading.Tasks;
using EasyManager.Domain.Events;
using MediatR;

namespace EasyManager.Domain.EventHandlers
{
    public class ManufactureEventHandler :
        INotificationHandler<ManufactureRegisteredEvent>,
        INotificationHandler<ManufactureUpdatedEvent>,
        INotificationHandler<ManufactureRemovedEvent>
    {
        public Task Handle(ManufactureRegisteredEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(ManufactureUpdatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(ManufactureRemovedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}