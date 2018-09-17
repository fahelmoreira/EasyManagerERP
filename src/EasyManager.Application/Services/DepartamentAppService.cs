using AutoMapper;
using EasyManager.Application.Interfaces;
using EasyManager.Application.ViewModels;
using EasyManager.Domain.Commands;
using EasyManager.Domain.Core.Bus;
using EasyManager.Domain.Interfaces;
using EasyManager.Infra.Data.Repository.EventSourcing;

namespace EasyManager.Application.Services
{
    public class DepartamentAppService :
        BaseAppService<Domain.Models.Departament,
                       DepartamentViewModel,
                       IDepartamentRepository,
                       RegisterNewDepartamentCommand,
                       RemoveDepartamentCommand,
                       UpdateDepartamentCommand>,
        IDepartamentService
    {
        public DepartamentAppService(IMapper mapper, 
                                     IDepartamentRepository repository, 
                                     IMediatorHandler bus, 
                                     IEventStoreRepository eventStoreRepository) : base(mapper, repository, bus, eventStoreRepository)
        {
        }
    }
}