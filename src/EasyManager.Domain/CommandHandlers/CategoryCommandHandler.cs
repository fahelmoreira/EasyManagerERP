using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EasyManager.Domain.Commands;
using EasyManager.Domain.Core.Bus;
using EasyManager.Domain.Core.Notifications;
using EasyManager.Domain.Core.Units;
using EasyManager.Domain.Events;
using EasyManager.Domain.Interfaces;
using EasyManager.Domain.Models;
using MediatR;

namespace EasyManager.Domain.CommandHandlers
{
    public class CategoryCommandHandler : 
        BaseCommandsHandler<Category,
                      ICaregoryRepository,
                      RegisterNewCategoryCommand,
                      CategoryRegisteredEvent,
                      RemoveCategoryCommand,
                      CategoryRemovedEvent,
                      UpdateCategoryCommand,
                      CategoryUpdatedEvent>
    {
        public CategoryCommandHandler(IMapper mapper, 
                                      ICaregoryRepository repository, 
                                      IUnitOfWork uow, 
                                      IMediatorHandler bus, 
                                      INotificationHandler<DomainNotification> notifications) : base(mapper, repository, uow, bus, notifications)
        {
        }

        protected internal override void ConstraintValidation(Category category, out Category category2)
        {
            Category parent = null;

            if(category.ParentCategory != null)
            {
                parent = _repository.GetById(category.ParentCategory.Id);

                if(parent == null)
                {
                    _bus.RaiseEvent(new DomainNotification("Parent invalid", "The parent category is not valid"));
                    category2 = null;
                    return;
                }
            }

            category.ParentCategory = parent;
            category2 = category;
        }

    }
}