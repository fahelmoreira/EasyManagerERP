using AutoMapper;
using EasyManager.Domain.Commands;
using EasyManager.Domain.Core.Bus;
using EasyManager.Domain.Core.Notifications;
using EasyManager.Domain.Events;
using EasyManager.Domain.Interfaces;
using EasyManager.Domain.Models;
using MediatR;

namespace EasyManager.Domain.CommandHandlers
{
    public class OrderCommandHandler :
        BaseCommandsHandler<Order,
                    IOrderRepository,
                    RegisterNewOrderCommand,
                    OrderRegisteredEvent,
                    RemoveOrderCommand,
                    OrderRemovedEvent,
                    UpdateOrderCommand,
                    OrderUpdatedEvent>
    {
        public OrderCommandHandler(IMapper mapper, 
                                   IOrderRepository repository, 
                                   IUnitOfWork uow, 
                                   IMediatorHandler bus, 
                                   INotificationHandler<DomainNotification> notifications) : base(mapper, repository, uow, bus, notifications)
        {
        }
    }
}