using AutoMapper;
using EasyManager.Application.Interfaces;
using EasyManager.Application.ViewModels;
using EasyManager.Domain.Commands;
using EasyManager.Domain.Core.Bus;
using EasyManager.Domain.Interfaces;
using EasyManager.Infra.Data.Repository.EventSourcing;

namespace EasyManager.Application.Services
{
    public class PaymentMethodAppService :
        BaseAppService<Domain.Models.PaymentMethod,
                       PaymentMethodViewModel,
                       PaymentMethodShotViewModel,
                       IPaymentMethodRepository,
                       RegisterNewPaymentMethodCommand,
                       RemovePaymentMethodCommand,
                       UpdatePaymentMethodCommand>,
        IPaymentMethodAppService
    {
        public PaymentMethodAppService(IMapper mapper, 
                                       IPaymentMethodRepository repository, 
                                       IMediatorHandler bus, 
                                       IEventStoreRepository eventStoreRepository) : base(mapper, repository, bus, eventStoreRepository)
        {
        }
    }
}