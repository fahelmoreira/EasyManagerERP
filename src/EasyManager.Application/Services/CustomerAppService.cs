using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EasyManager.Application.Interfaces;
using EasyManager.Application.ViewModels;
using EasyManager.Domain.Commands;
using EasyManager.Domain.Core.Bus;
using EasyManager.Domain.Core.Units;
using EasyManager.Domain.Interfaces;
using EasyManager.Infra.Data.Repository.EventSourcing;

namespace EasyManager.Application.Services
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler _bus;

        public CustomerAppService(IMapper mapper,
                                  ICustomerRepository customerRepository,
                                  IMediatorHandler bus,
                                  IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }

        public IEnumerable<CustomerShortViewModel> GetAll()
        {
            return _customerRepository.GetAll().ProjectTo<CustomerShortViewModel>();
        }

        public CustomerViewModel GetById(Guid id)
        {
           var customer = _customerRepository.GetById(id);

           return _mapper.Map<CustomerViewModel>(customer);
        }

        public void Register(CustomerViewModel customerViewModel)
        {
            var RegisterNewCustomerCommand = _mapper.Map<RegisterNewCustomerCommand>(customerViewModel);
            _bus.SendCommand<RegisterNewCustomerCommand, RegisterUnit>(RegisterNewCustomerCommand);
            
        }

        public void Remove(Guid id)
        {
            var RemoveCustomerCommand = new RemoveCustomerCommand(id);
            _bus.SendCommand<RemoveCustomerCommand, RemoveUnit>(RemoveCustomerCommand);
        }

        public void Update(CustomerViewModel customerViewModel)
        {
            var UpdateCustomerCommand = _mapper.Map<UpdateCustomerCommand>(customerViewModel);

            _bus.SendCommand<UpdateCustomerCommand, UpdateUnit>(UpdateCustomerCommand);
        }
    }
}