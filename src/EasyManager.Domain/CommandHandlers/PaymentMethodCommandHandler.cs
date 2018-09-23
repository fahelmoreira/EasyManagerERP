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
    public class PaymentMethodCommandHandler :
        BaseCommandsHandler<PaymentMethod,
                            IPaymentMethodRepository,
                            RegisterNewPaymentMethodCommand,
                            PaymentMethodRegisteredEvent,
                            RemovePaymentMethodCommand,
                            PaymentMethodRemovedEvent,
                            UpdatePaymentMethodCommand,
                            PaymentMethodUpdatedEvent>
    {
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly ICredcardOperatorRepository _credcardOperatorRepository;

        public PaymentMethodCommandHandler(IMapper mapper, 
                                           IPaymentMethodRepository repository, 
                                           IBankAccountRepository bankAccountRepository,
                                           ICredcardOperatorRepository credcardOperatorRepository,
                                           IUnitOfWork uow, 
                                           IMediatorHandler bus, 
                                           INotificationHandler<DomainNotification> notifications) : base(mapper, repository, uow, bus, notifications)
        {
            _bankAccountRepository = bankAccountRepository;
            _credcardOperatorRepository = credcardOperatorRepository;
        }

        protected internal override void ConstraintValidation(PaymentMethod payment1, out PaymentMethod payment2)
        {
            BankAccount bankAccount = null;
            CredcardOperator credcardOperator = null;
            bool isValid = true;
            
            if(payment1.BankAccount != null)
            {
                bankAccount = _bankAccountRepository.GetById(payment1.BankAccount.Id);
                credcardOperator = _credcardOperatorRepository.GetById(payment1.CredcardOperator.Id);

                if(bankAccount == null)
                    _bus.RaiseEvent(new DomainNotification("Bankaccount invalid", "The bankaccount is not valid"));

                if(credcardOperator == null)
                    _bus.RaiseEvent(new DomainNotification("Credcard invalid", "The credcard operator is not valid"));

                if(!isValid)
                {
                    payment2 = null;
                    return;
                }

            }

            payment1.BankAccount = bankAccount;
            payment1.CredcardOperator = credcardOperator;
            payment2 = payment1;
        }
    }
}