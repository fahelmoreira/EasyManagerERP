using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EasyManager.Domain.Commands;
using EasyManager.Domain.Core.Bus;
using EasyManager.Domain.Core.Notifications;
using EasyManager.Domain.Events;
using EasyManager.Domain.Interfaces;
using EasyManager.Domain.Models;
using MediatR;

namespace EasyManager.Domain.CommandHandlers
{
    public class ManufactureCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewManufactureCommand>,
        IRequestHandler<UpdateManufactureCommand>,
        IRequestHandler<RemoveManufactureCommand>
    {
        private readonly IManufactureRepository _ManufactureRepository;

        public ManufactureCommandHandler(IMapper mapper, 
                                         IManufactureRepository manufactureRepository,
                                         IUnitOfWork uow, 
                                         IMediatorHandler bus, 
                                         INotificationHandler<DomainNotification> notifications) : base(mapper, uow, bus, notifications)
        {
            _ManufactureRepository = manufactureRepository;
        }

        public async Task<Unit> Handle(RegisterNewManufactureCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyValidationErrors(command);
                return Unit.Value;
            }

            var manufacture = _mapper.Map<Manufacture>(command);

            _ManufactureRepository.Add(manufacture);

            if(Commit())
                await _bus.RaiseEvent(_mapper.Map<ManufactureRegisteredEvent>(command));

            return Unit.Value;
        }

        public async Task<Unit> Handle(UpdateManufactureCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyValidationErrors(command);
                return Unit.Value;
            }

            var manufacture = _mapper.Map<Manufacture>(command);

            _ManufactureRepository.Update(manufacture);

            if(Commit())
                await _bus.RaiseEvent(_mapper.Map<ManufactureUpdatedEvent>(command));

            return Unit.Value;

        }

        public async Task<Unit> Handle(RemoveManufactureCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyValidationErrors(command);
                return Unit.Value;
            }

             _ManufactureRepository.Remove(command.Id);

              if(Commit())
                await _bus.RaiseEvent(_mapper.Map<ManufactureRemovedEvent>(command));

            return Unit.Value;
        }
    }
}