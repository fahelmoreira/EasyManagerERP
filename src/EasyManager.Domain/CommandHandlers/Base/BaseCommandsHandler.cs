using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EasyManager.Domain.Commands;
using EasyManager.Domain.Core.Bus;
using EasyManager.Domain.Core.Commands;
using EasyManager.Domain.Core.Events;
using EasyManager.Domain.Core.Model;
using EasyManager.Domain.Core.Notifications;
using EasyManager.Domain.Core.Units;
using EasyManager.Domain.Events;
using EasyManager.Domain.Interfaces;
using MediatR;

namespace EasyManager.Domain.CommandHandlers
{
    public abstract class BaseCommandsHandler<TEntity, 
                              Repository,
                              RegisterCommand, 
                              RegisterEvent,
                              RemoveCommand, 
                              RemoveEvent,
                              UpdateCommand,
                              UpdateEvent> :
        CommandHandler<Repository>,
        IRequestHandler<RegisterCommand, RegisterUnit>, 
        IRequestHandler<RemoveCommand, RemoveUnit>,
        IRequestHandler<UpdateCommand, UpdateUnit>
        where TEntity : Entity
        where Repository : IRepository<TEntity>
        where RegisterCommand : Command<RegisterUnit>
        where RemoveCommand : Command<RemoveUnit>
        where UpdateCommand : Command<UpdateUnit>
        where RegisterEvent : Event
        where RemoveEvent : Event
        where UpdateEvent : Event
    {
        public BaseCommandsHandler(IMapper mapper, 
                            Repository repository, 
                            IUnitOfWork uow, IMediatorHandler bus, 
                            INotificationHandler<DomainNotification> notifications) : base(mapper, repository, uow, bus, notifications)
        {
        }

        /// <summary>
        /// Regiter the entity <TEntity> in the data base
        /// </summary>
        /// <param name="command">Command to be executed</param>
        /// <param name="cancellationToken"></param>
        public async Task<RegisterUnit> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyValidationErrors(command);
                return RegisterUnit.Value;
            }
            
            try
            {
                var bankAccount = _mapper.Map<TEntity>(command);
                _repository.Add(bankAccount);
                
            }
            catch (System.Exception ex)
            {
                Console.Write(ex.Message);

                await _bus.RaiseEvent(new DomainNotification("Parse", "We had a problem during saving your data."));
                throw;
            }


            if (Commit())
                await _bus.RaiseEvent(_mapper.Map<RegisterEvent>(command));

            return RegisterUnit.Value;
        }

        /// <summary>
        /// Removes the entity <TEntity> from the data base
        /// </summary>
        /// <param name="command">Command to be executed</param>
        /// <param name="cancellationToken"></param>
        public async Task<RemoveUnit> Handle(RemoveCommand command, CancellationToken cancellationToken)
        {
             if(!command.IsValid())
            {
                NotifyValidationErrors(command);
                return RemoveUnit.Value;
            }

            _repository.Remove(command.Id);

            if(Commit())
                await _bus.RaiseEvent(_mapper.Map<RemoveEvent>(command));
            
            return RemoveUnit.Value;
        }

        /// <summary>
        /// Updates the entity <TEntity> in the data base
        /// </summary>
        /// <param name="command">Command to be executed</param>
        /// <param name="cancellationToken"></param>
        public async Task<UpdateUnit> Handle(UpdateCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyValidationErrors(command);
                return UpdateUnit.Value;
            }

            var bankAccount = _mapper.Map<TEntity>(command);

            _repository.Update(bankAccount);

            if (Commit())
                await _bus.RaiseEvent(_mapper.Map<UpdateEvent>(command));

            return UpdateUnit.Value;
        }
    }
}