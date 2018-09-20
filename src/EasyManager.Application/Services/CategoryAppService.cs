using AutoMapper;
using EasyManager.Application.Interfaces;
using EasyManager.Application.ViewModels;
using EasyManager.Domain.Commands;
using EasyManager.Domain.Core.Bus;
using EasyManager.Domain.Interfaces;
using EasyManager.Infra.Data.Repository.EventSourcing;

namespace EasyManager.Application.Services
{
    public class CategoryAppService :
        BaseAppService<Domain.Models.Category,
                       CategoryViewModel,
                       ICaregoryRepository,
                       RegisterNewCategoryCommand,
                       RemoveCategoryCommand,
                       UpdateCategoryCommand>,
        ICategoryAppService
    {
        public CategoryAppService(IMapper mapper, 
                                  ICaregoryRepository repository, 
                                  IMediatorHandler bus, 
                                  IEventStoreRepository eventStoreRepository) : base(mapper, repository, bus, eventStoreRepository)
        {
        }
    }
}