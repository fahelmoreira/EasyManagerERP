using EasyManager.Domain.Core.Bus;
using EasyManager.Domain.Core.Notifications;
using EasyManager.Domain.Interfaces;
using MediatR;

namespace EasyManager.Domain.CommandHandlers
{
    public class CustomerCommandHandler : CommandHandler
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

        public async Task HandlerAysnc()
        {

        }
    }
}