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
    public class PurchaseCommandHandler :
        BaseCommandsHandler<Purchase,
                            IPurchaseRepository,
                            RegisterNewPurchaseCommand,
                            PurchaseRegisteredEvent,
                            RemovePurchaseCommand,
                            PurchaseRemovedEvent,
                            UpdatePurchaseCommand,
                            PurchaseUpdatedEvent>
    {
        public PurchaseCommandHandler(IMapper mapper, 
                                      IPurchaseRepository repository, 
                                      IUnitOfWork uow, 
                                      IMediatorHandler bus, 
                                      INotificationHandler<DomainNotification> notifications) : base(mapper, repository, uow, bus, notifications)
        {
        }
    }
}