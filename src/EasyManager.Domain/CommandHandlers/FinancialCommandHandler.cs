using System;
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
    public class FinancialCommandHandler :
        BaseCommandsHandler<Financial,
                            IFinancialRepository,
                            RegisterNewFinancialCommand,
                            FinancialRegisteredEvent,
                            RemoveFinancialCommand,
                            FinancialRemovedEvent,
                            UpdateFinancialCommand,
                            FinancialUpdatedEvent>
    {
        private readonly IPaymentMethodRepository _paymentMethodRepository;

        public FinancialCommandHandler(IMapper mapper, 
                                       IFinancialRepository repository, 
                                       IPaymentMethodRepository paymentMethodRepository,
                                       IUnitOfWork uow, 
                                       IMediatorHandler bus, 
                                       INotificationHandler<DomainNotification> notifications) : base(mapper, repository, uow, bus, notifications)
        {
            _paymentMethodRepository = paymentMethodRepository;
        }

        protected internal override void ConstraintValidation(Financial financial, out Financial financial2)
        {
            PaymentMethod paymentMethod = null;
            
            //Validates the payment method
            if(!financial.PaymentMethod.IsNull())
            {
                paymentMethod = _paymentMethodRepository.GetById(financial.PaymentMethod.Id);

                if(paymentMethod == null)
                {
                    _bus.RaiseEvent(new DomainNotification("Payment method invalid", "The payment method is not valid"));
                    financial2 = null;
                    return;
                }
            }

            financial.PaymentMethod = paymentMethod;
            financial2 = financial;
        }
    }
}