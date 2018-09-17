using System;
using System.Collections.Generic;
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
    public class ManufactureAppServices :
        BaseAppService<Domain.Models.Manufacture,
                       ManufactureViewModel,
                       ManufactureShortViewModel,
                       IManufactureRepository,
                       RegisterNewManufactureCommand,
                       RemoveManufactureCommand,
                       UpdateManufactureCommand>,
        IManufactureAppServices
    {
        public ManufactureAppServices(IMapper mapper, 
                                      IManufactureRepository repository, 
                                      IMediatorHandler bus, 
                                      IEventStoreRepository eventStoreRepository) : base(mapper, repository, bus, eventStoreRepository)
        {
        }
    }
}