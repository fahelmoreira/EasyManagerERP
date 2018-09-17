using AutoMapper;
using EasyManager.Application.Interfaces;
using EasyManager.Application.ViewModels;
using EasyManager.Domain.Commands;
using EasyManager.Domain.Core.Bus;
using EasyManager.Domain.Interfaces;
using EasyManager.Infra.Data.Repository.EventSourcing;

namespace EasyManager.Application.Services
{
    public class SalesTableAppService :
        BaseAppService<Domain.Models.SalesTable,
                       SalesTableViewModel,
                       ISalesTableRepository,
                       RegisterNewSalesTableItemCommand,
                       RemoveSalesTableItemCommand,
                       UpdateSalesTableItemCommand>,
        ISalesTableService
    {
        public SalesTableAppService(IMapper mapper, 
                                    ISalesTableRepository repository, 
                                    IMediatorHandler bus, 
                                    IEventStoreRepository eventStoreRepository) : base(mapper, repository, bus, eventStoreRepository)
        {
        }
    }
}