using System.Threading;
using System.Threading.Tasks;
using EasyManager.Domain.Events;
using MediatR;

namespace EasyManager.Domain.EventHandlers
{
    public class CategoryEventHandler :
        INotificationHandler<CategoryRegisteredEvent>,
        INotificationHandler<CategoryRemovedEvent>,
        INotificationHandler<CategoryUpdatedEvent>
    {
        public Task Handle(CategoryRegisteredEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(CategoryRemovedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
        public Task Handle(CategoryUpdatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}