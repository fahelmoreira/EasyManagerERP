using AutoMapper;
using EasyManager.Application.Interfaces;
using EasyManager.Application.ViewModels;
using EasyManager.Domain.Commands;
using EasyManager.Domain.Core.Bus;
using EasyManager.Domain.Interfaces;
using EasyManager.Infra.Data.Repository.EventSourcing;

namespace EasyManager.Application.Services
{
    public class PurchaseAppService :
        BaseAppService<Domain.Models.Purchase,
                       PurchaseViewModel,
                       PurchaseShortViewModel,
                       IPurchaseRepository,
                       RegisterNewPurchaseCommand,
                       RemovePurchaseCommand,
                       UpdatePurchaseCommand>,
        IPurchaseService
    {
        public PurchaseAppService(IMapper mapper, 
                                  IPurchaseRepository repository, 
                                  IMediatorHandler bus, 
                                  IEventStoreRepository eventStoreRepository) : base(mapper, repository, bus, eventStoreRepository)
        {
        }
    }
}