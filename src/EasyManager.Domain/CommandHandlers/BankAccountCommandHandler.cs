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
        private readonly IBankRepository _bankRepository;

        public BankAccountCommandHandler(IMapper mapper, 
                                         IBankAccountRepository repository, 
                                         IBankRepository bankRepository,
                                         IUnitOfWork uow, 
                                         IMediatorHandler bus, 
                                         INotificationHandler<DomainNotification> notifications) : base(mapper, repository, uow, bus, notifications)
        {
            _bankRepository = bankRepository;
        }

        protected internal override void ConstraintValidation(BankAccount bankAccount, out BankAccount bankAccount2)
        {
            Bank bank = null;
            
            // Validate the bank
            if(bankAccount.Bank != null)
            {
                bank = _bankRepository.GetById(bankAccount.Bank.Id);

                if(bank == null)
                {
                    _bus.RaiseEvent(new DomainNotification("Bank invalid", "The bank is not valid"));
                    bankAccount2 = null;
                    return;
                }
            }

            bankAccount.Bank = bank;
            bankAccount2 = bankAccount;
        }
    }
}