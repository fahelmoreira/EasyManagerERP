using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EasyManager.Application.Interfaces;
using EasyManager.Domain.Core.Bus;
using EasyManager.Domain.Core.Commands;
using EasyManager.Domain.Core.Units;
using EasyManager.Domain.Interfaces;
using EasyManager.Infra.Data.Repository.EventSourcing;

namespace EasyManager.Application.Services
{
    /// <summary>
    /// Base services
    /// </summary>
    /// <typeparam name="Entity">Entity of the service</typeparam>
    /// <typeparam name="ViewMode">ViewModel of the service</typeparam>
    /// <typeparam name="ViewModeShort">Shot version of the service's view model</typeparam>
    /// <typeparam name="Repository">Repository</typeparam>
    /// <typeparam name="RegisterCommand">Register command</typeparam>
    /// <typeparam name="RemoveCommand">Remove command</typeparam>
    /// <typeparam name="UpdateCommand">Update command</typeparam>
    public abstract class BaseAppService<Entity, 
                                         ViewMode, 
                                         ViewModeShort, 
                                         Repository, 
                                         RegisterCommand, 
                                         RemoveCommand, 
                                         UpdateCommand> : 
            IAppServices<ViewMode,ViewModeShort>
            where Repository : IRepository<Entity>
            where Entity : Domain.Core.Model.Entity
            where ViewMode : class
            where ViewModeShort : class
            where RegisterCommand : Command<RegisterUnit>
            where RemoveCommand : Command<RemoveUnit>
            where UpdateCommand : Command<UpdateUnit>
    {
        private readonly IMapper _mapper;
        private readonly Repository _repository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler _bus;

        public BaseAppService(IMapper mapper,
                              Repository repository,
                              IMediatorHandler bus,
                              IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }

        public IEnumerable<ViewModeShort> GetAll()
        {
            return _repository.GetAll().ProjectTo<ViewModeShort>();
        }

        public ViewMode GetById(Guid id)
        {
            var customer = _repository.GetById(id);
            return _mapper.Map<ViewMode>(customer);
        }

        public void Register(ViewMode ViewModel)
        {
            var RegisterCommand = _mapper.Map<RegisterCommand>(ViewModel);
            _bus.SendCommand<RegisterCommand, RegisterUnit>(RegisterCommand);
        }

        public void Remove(Guid id)
        {
            var RemoveCommand = _mapper.Map<RemoveCommand>(id);
            _bus.SendCommand<RemoveCommand, RemoveUnit>(RemoveCommand);
        }

        public void Update(ViewMode ViewModel)
        {
            var UpdateCommand = _mapper.Map<UpdateCommand>(ViewModel);
            _bus.SendCommand<UpdateCommand, UpdateUnit>(UpdateCommand);
        }
    }

    /// <summary>
    /// Base services
    /// </summary>
    /// <typeparam name="Entity">Entity of the service</typeparam>
    /// <typeparam name="ViewMode">ViewModel of the service</typeparam>
    /// <typeparam name="Repository">Repository</typeparam>
    /// <typeparam name="RegisterCommand">Register command</typeparam>
    /// <typeparam name="RemoveCommand">Remove command</typeparam>
    /// <typeparam name="UpdateCommand">Update command</typeparam>
    public abstract class BaseAppService<Entity,
                                         ViewMode,
                                         Repository,
                                         RegisterCommand,
                                         RemoveCommand,
                                         UpdateCommand> :
                          BaseAppService<Entity,
                                         ViewMode,
                                         ViewMode,
                                         Repository,
                                         RegisterCommand,
                                         RemoveCommand,
                                         UpdateCommand>,
        IAppServices<ViewMode>
        where Repository : IRepository<Entity>
        where Entity : Domain.Core.Model.Entity
        where ViewMode : class
        where RegisterCommand : Command<RegisterUnit>
        where RemoveCommand : Command<RemoveUnit>
        where UpdateCommand : Command<UpdateUnit>
    {
        public BaseAppService(IMapper mapper, 
                              Repository repository, 
                              IMediatorHandler bus, 
                              IEventStoreRepository eventStoreRepository) : base(mapper, repository, bus, eventStoreRepository)
        {
        }
    }
}