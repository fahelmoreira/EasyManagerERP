using System.Threading;
using System.Threading.Tasks;
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
    public class BankAccountCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewBankAccountCommand>,
        IRequestHandler<RemoveBankAccountCommand>,
        IRequestHandler<UpdateBankAccountCommand>
    {
        private readonly IBankAccountRepository _bankAccountRepository;

        public BankAccountCommandHandler(IMapper mapper,
                                         IBankAccountRepository bankAccountRepository, 
                                         IUnitOfWork uow, 
                                         IMediatorHandler bus, 
                                         INotificationHandler<DomainNotification> notifications) : base(mapper, uow, bus, notifications)
        {
            _bankAccountRepository = bankAccountRepository;
        }

        public async Task<Unit> Handle(RegisterNewBankAccountCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyValidationErrors(command);
                return Unit.Value;
            }

            var bankAccount = _mapper.Map<BankAccount>(command);

            _bankAccountRepository.Add(bankAccount);

            if (Commit())
                await _bus.RaiseEvent(_mapper.Map<BankAccountRegisteredEvent>(command));

            return Unit.Value;
        }

        public async Task<Unit> Handle(RemoveBankAccountCommand command, CancellationToken cancellationToken)
        {
             if (!command.IsValid())
            {
                NotifyValidationErrors(command);
                return Unit.Value;
            }

            _bankAccountRepository.Remove(command.Id);

            if (Commit())
                await _bus.RaiseEvent(_mapper.Map<BankAccountRemovedEvent>(command));

            return Unit.Value;
        }

        public async Task<Unit> Handle(UpdateBankAccountCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyValidationErrors(command);
                return Unit.Value;
            }

            var bankAccount = _mapper.Map<BankAccount>(command);

            _bankAccountRepository.Update(bankAccount);

            if (Commit())
                await _bus.RaiseEvent(_mapper.Map<BankAccountUpdatedEvent>(command));

            return Unit.Value;
        }
    }
}