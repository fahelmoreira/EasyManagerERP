using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EasyManager.Application.Interfaces;
using EasyManager.Application.ViewModels;
using EasyManager.Domain.Commands;
using EasyManager.Domain.Core.Bus;
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

        public IEnumerable<CustomerViewModel> GetAll()
        {
            var customer = _customerRepository.GetAll().ToList();

            //return new List<CustomerViewModel>();
            
            return _mapper.Map<List<CustomerViewModel>>(customer);
        }

        public CustomerViewModel GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Register(CustomerViewModel customerViewModel)
        {
            var RegisterNewCustomerCommand = _mapper.Map<RegisterNewCustomerCommand>(customerViewModel);
            _bus.SendCommand(RegisterNewCustomerCommand);
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(CustomerViewModel customerViewModel)
        {
            throw new NotImplementedException();
        }
    }
}