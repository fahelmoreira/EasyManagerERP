using AutoMapper;
using EasyManager.Application.Interfaces;
using EasyManager.Application.ViewModels;
using EasyManager.Domain.Commands;
using EasyManager.Domain.Core.Bus;
using EasyManager.Domain.Interfaces;
using EasyManager.Infra.Data.Repository.EventSourcing;

namespace EasyManager.Application.Services
{
    public class FinancialAppService :
        BaseAppService<Domain.Models.Financial,
                       FinancialViewModel,
                       FinancialShortViewModel,
                       IFinancialRepository,
                       RegisterNewFinancialCommand,
                       RemoveFinancialCommand,
                       UpdateFinancialCommand>,
        IFinancialService
    {
        public FinancialAppService(IMapper mapper, 
                                   IFinancialRepository repository, 
                                   IMediatorHandler bus, 
                                   IEventStoreRepository eventStoreRepository) : base(mapper, repository, bus, eventStoreRepository)
        {
        }
    }
}