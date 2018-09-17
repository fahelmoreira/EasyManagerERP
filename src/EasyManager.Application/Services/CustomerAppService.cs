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
    public class CustomerAppService :
        BaseAppService<Domain.Models.Customer,
                       CustomerViewModel,
                       CustomerShortViewModel,
                       ICustomerRepository,
                       RegisterNewCustomerCommand,
                       RemoveCustomerCommand,
                       UpdateCustomerCommand> ,
        ICustomerAppService
        
    {
        public CustomerAppService(IMapper mapper,
                                  ICustomerRepository repository, 
                                  IMediatorHandler bus, 
                                  IEventStoreRepository eventStoreRepository) : base(mapper, repository, bus, eventStoreRepository)
        {
        }
    }
}