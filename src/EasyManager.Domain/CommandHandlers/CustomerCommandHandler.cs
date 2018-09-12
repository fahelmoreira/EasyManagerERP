using System.Threading;
using System.Threading.Tasks;
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
        public CustomerCommandHandler(ICustomerRepository customerRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,   
                                      INotificationHandler<DomainNotification> notification) : base(uow, bus, notification)
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

            var customer = new Customer { 
                TradeName = command.TradeName, 
                CorporateTaxpayerId = command.CorporateTaxpayerId,
                IndividualTaxpayerId = command.IndividualTaxpayerId,
                Type = command.Type,
                Address = JsonConvert.SerializeObject(command.Address), 
                Contacts = JsonConvert.SerializeObject(command.Contacts),
            };

            _customerRepository.Add(customer);

            if (Commit())
                await _bus.RaiseEvent(new CustomerRegisteredEvent(customer.Id,
                                                                 command.TradeName, 
                                                                 command.Type, 
                                                                 command.IndividualTaxpayerId, 
                                                                 command.CorporateTaxpayerId,
                                                                 command.Address,
                                                                 command.Contacts));

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
                return new Unit();
            }

            _customerRepository.Remove(command.Id);

            if(await CommitAsync())
                await _bus.RaiseEvent(new CustomerRemovedEvent(command.Id));
            
            return new Unit();
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
                return new Unit();
            }
            var customer = new Customer{ Id = command.Id, TradeName = command.TradeName };
            _customerRepository.Update(customer);

            if(await CommitAsync())
                await _bus.RaiseEvent(new CustomerUpdatedEvent(customer.Id,
                                                              command.TradeName, 
                                                              command.Type, 
                                                              command.IndividualTaxpayerId, 
                                                              command.CorporateTaxpayerId,
                                                              command.Address,
                                                              command.Contacts));
            
            return new Unit();
        }
    }
}