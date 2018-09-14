using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EasyManager.Domain.Commands;
using EasyManager.Domain.Core.Bus;
using EasyManager.Domain.Core.Notifications;
using EasyManager.Domain.Core.Units;
using EasyManager.Domain.Events;
using EasyManager.Domain.Interfaces;
using EasyManager.Domain.Models;
using MediatR;

namespace EasyManager.Domain.CommandHandlers
{
    public class BankAccountCommandHandler :
        BaseCommandsHandler<BankAccount,
                      IBankAccountRepository,
                      RegisterNewBankAccountCommand,
                      BankAccountRegisteredEvent,
                      RemoveBankAccountCommand,
                      BankAccountRemovedEvent,
                      UpdateBankAccountCommand,
                      BankAccountUpdatedEvent>

    {
        public BankAccountCommandHandler(IMapper mapper, 
                                         IBankAccountRepository repository, 
                                         IUnitOfWork uow, 
                                         IMediatorHandler bus, 
                                         INotificationHandler<DomainNotification> notifications) : base(mapper, repository, uow, bus, notifications)
        {
        }
    }
}