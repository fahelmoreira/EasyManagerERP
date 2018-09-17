using AutoMapper;
using EasyManager.Application.Interfaces;
using EasyManager.Application.ViewModels;
using EasyManager.Domain.Commands;
using EasyManager.Domain.Core.Bus;
using EasyManager.Domain.Interfaces;
using EasyManager.Infra.Data.Repository.EventSourcing;

namespace EasyManager.Application.Services
{
    public class OrderAppService :
        BaseAppService<Domain.Models.Order,
                       OrderViewModel,
                       OrderShortViewModel,
                       IOrderRepository,
                       RegisterNewOrderCommand,
                       RemoveOrderCommand,
                       UpdateOrderCommand>,
        IOrderService
    {
        public OrderAppService(IMapper mapper, 
                               IOrderRepository repository, 
                               IMediatorHandler bus, 
                               IEventStoreRepository eventStoreRepository) : base(mapper, repository, bus, eventStoreRepository)
        {
        }
    }
}