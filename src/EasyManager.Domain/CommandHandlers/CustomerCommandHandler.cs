using System.Threading;
using System.Threading.Tasks;
using EasyManager.Domain.Commands;
using EasyManager.Domain.Core.Bus;
using EasyManager.Domain.Core.Notifications;
using EasyManager.Domain.Events;
using EasyManager.Domain.Interfaces;
using EasyManager.Domain.Models;
using MediatR;

namespace EasyManager.Domain.CommandHandlers
{
    public class CustomerCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewCustomerCommand>
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
        /// <returns></returns>
        public async Task Handle(RegisterNewCustomerCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyValidationErrors(command);
                return;
            }

            var customer = new Customer { TradeName = command.TradeName };

            _customerRepository.Add(customer);

            if (await CommitAsync())
                await _bus.RaiseEvent(new CustomerRegisteredEvent(customer.Id,
                                                                 command.TradeName, 
                                                                 command.Type, 
                                                                 command.IndividualTaxpayerId, 
                                                                 command.CorporateTaxpayerId,
                                                                 command.Address,
                                                                 command.Contacts));
        
        }

        /// <summary>
        /// Handles the customer removal command
        /// </summary>
        /// <param name="command">Command to be executed</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task Handle(RemoveCustomerCommand command, CancellationToken cancellationToken)
        {
            if(!command.IsValid())
            {
                NotifyValidationErrors(command);
                return;
            }

            _customerRepository.Remove(command.Id);

            if(await CommitAsync())
                await _bus.RaiseEvent(new CustomerRemovedEvent(command.Id));
        }

        /// <summary>
        /// Handles the customer update command
        /// </summary>
        /// <param name="command">Command to be executed</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
        {
            if(!command.IsValid())
            {
                NotifyValidationErrors(command);
                return;
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
        }
    }
}