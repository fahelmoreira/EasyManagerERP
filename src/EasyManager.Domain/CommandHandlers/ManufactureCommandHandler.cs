using AutoMapper;
using EasyManager.Domain.Core.Bus;
using EasyManager.Domain.Core.Notifications;
using EasyManager.Domain.Interfaces;
using MediatR;

namespace EasyManager.Domain.CommandHandlers
{
    public class ManufactureCommandHandler : CommandHandler
    {
        public ManufactureCommandHandler(IMapper mapper, 
                                         IUnitOfWork uow, 
                                         IMediatorHandler bus, 
                                         INotificationHandler<DomainNotification> notifications) : base(mapper, uow, bus, notifications)
        {
        }

        
    }
}