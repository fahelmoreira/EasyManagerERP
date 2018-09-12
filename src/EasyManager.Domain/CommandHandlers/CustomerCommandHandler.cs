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
using Newtonsoft.Json;

namespace EasyManager.Domain.CommandHandlers
{
    public class CustomerCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewCustomerCommand>,
        IRequestHandler<UpdateCustomerCommand>,
        IRequestHandler<RemoveCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;

        /// <summary>
        /// Default constructor
        /// </summary>
        public CustomerCommandHandler(IMapper mapper,
                                      ICustomerRepository customerRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,   
                                      INotificationHandler<DomainNotification> notification) : base(mapper, uow, bus, notification)
        {
            _customerRepository = customerRepository;
        }
        
        /// <summary>
        /// Handles the customer registration command
        /// </summary>
        /// <param name="command">Command to be executed</param>
        /// <param name="cancellationToken"></param>
        async Task<Unit> IRequestHandler<RegisterNewCustomerCommand, Unit>.Handle(RegisterNewCustomerCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyValidationErrors(command);
                return Unit.Value;
            }

            var customer = _mapper.Map<Customer>(command);

            _customerRepository.Add(customer);

            if (Commit())
                await _bus.RaiseEvent(_mapper.Map<CustomerRegisteredEvent>(command));

            return Unit.Value;
        }

        /// <summary>
        /// Handles the customer removal command
        /// </summary>
        /// <param name="command">Command to be executed</param>
        /// <param name="cancellationToken"></param>
        async Task<Unit> IRequestHandler<RemoveCustomerCommand, Unit>.Handle(RemoveCustomerCommand command, CancellationToken cancellationToken)
        {
            if(!command.IsValid())
            {
                NotifyValidationErrors(command);
                return Unit.Value;
            }

            _customerRepository.Remove(command.Id);

            if(Commit())
                await _bus.RaiseEvent(new CustomerRemovedEvent(command.Id));
            
            return Unit.Value;
        }

        /// <summary>
        /// Handles the customer update command
        /// </summary>
        /// <param name="command">Command to be executed</param>
        /// <param name="cancellationToken"></param>
        async Task<Unit> IRequestHandler<UpdateCustomerCommand, Unit>.Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
        {
            if(!command.IsValid())
            {
                NotifyValidationErrors(command);
                return Unit.Value;
            }
            var customer = _mapper.Map<Customer>(command);
            _customerRepository.Update(customer);

            if(Commit())
                await _bus.RaiseEvent(_mapper.Map<CustomerUpdatedEvent>(command));

            return Unit.Value;
        }
    }
}