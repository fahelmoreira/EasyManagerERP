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
    public class SalesTableCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewSalesTableItemCommand>,
        IRequestHandler<UpdateSalesTableItemCommand>,
        IRequestHandler<RemoveSalesTableItemCommand>
    {
        private readonly ISalesTableRepository _salesTableRepository;

        public SalesTableCommandHandler(IMapper mapper, 
                                        ISalesTableRepository salesTableRepository,
                                        IUnitOfWork uow, 
                                        IMediatorHandler bus, 
                                        INotificationHandler<DomainNotification> notifications) : base(mapper, uow, bus, notifications)
        {
            _salesTableRepository = salesTableRepository;
        }

        public async Task<Unit> Handle(RegisterNewSalesTableItemCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyValidationErrors(command);
                return Unit.Value;
            }

            var salesTable = _mapper.Map<SalesTable>(command);

            _salesTableRepository.Add(salesTable);

            if(Commit())
                await _bus.RaiseEvent(_mapper.Map<SalesTableItemRegisteredEvent>(command));

            return Unit.Value;

        }

        public async Task<Unit> Handle(UpdateSalesTableItemCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyValidationErrors(command);
                return Unit.Value;
            }

            var salesTable = _mapper.Map<SalesTable>(command);

            _salesTableRepository.Update(salesTable);

            if(Commit())
                await _bus.RaiseEvent(_mapper.Map<SalesTableItemUpdatedEvent>(command));

            return Unit.Value;
        }

        public async Task<Unit> Handle(RemoveSalesTableItemCommand command, CancellationToken cancellationToken)
        {
             if (!command.IsValid())
            {
                NotifyValidationErrors(command);
                return Unit.Value;
            }

            _salesTableRepository.Remove(command.Id);

            if(Commit())
                await _bus.RaiseEvent(_mapper.Map<SalesTableItemRemovedEvent>(command));

            return Unit.Value;
        }
    }
}