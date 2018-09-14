
using System.Threading;
using System.Threading.Tasks;
using EasyManager.Domain.Events;
using MediatR;

namespace EasyManager.Domain.EventHandlers
{
    public class DepartamentEventHandler :
        INotificationHandler<DepartamentRegisteredEvent>,
        INotificationHandler<DepartamentRemovedEvent>,
        INotificationHandler<DepartamentUpdatedEvent>
    {
        public Task Handle(DepartamentRegisteredEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(DepartamentRemovedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(DepartamentUpdatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}