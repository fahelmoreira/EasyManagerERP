using AutoMapper;
using EasyManager.Application.Interfaces;
using EasyManager.Application.ViewModels;
using EasyManager.Domain.Commands;
using EasyManager.Domain.Core.Bus;
using EasyManager.Domain.Interfaces;
using EasyManager.Infra.Data.Repository.EventSourcing;

namespace EasyManager.Application.Services
{
    public class ProductAppService :
        BaseAppService<Domain.Models.Product,
                       ProductViewModel,
                       ProductShortViewModel,
                       IProductRepository,
                       RegisterNewProductCommand,
                       RemoveProductCommand,
                       UpdateProductCommand>,
        IProductAppService
    {
        public ProductAppService(IMapper mapper, 
                                 IProductRepository repository, 
                                 IMediatorHandler bus, 
                                 IEventStoreRepository eventStoreRepository) : base(mapper, repository, bus, eventStoreRepository)
        {
        }
    }
}