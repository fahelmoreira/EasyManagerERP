using System;
using System.Collections.Generic;
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
    public class ManufactureAppServices : IManufactureAppServices
    {
        private readonly IMapper _mapper;
        private readonly IManufactureRepository _manufactureRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler _bus;

        public ManufactureAppServices(IMapper mapper,
                                      IManufactureRepository manufactureRepository,
                                      IMediatorHandler bus,
                                      IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _manufactureRepository = manufactureRepository;
            _bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }

        public IEnumerable<ManufactureShortViewModel> GetAll()
        {
            return _manufactureRepository.GetAll().ProjectTo<ManufactureShortViewModel>();
        }

        public ManufactureViewModel GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Register(ManufactureViewModel manufacture)
        {
            var RegisterNewManufactureCommand = _mapper.Map<RegisterNewManufactureCommand>(manufacture);
            _bus.SendCommand(RegisterNewManufactureCommand);
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(ManufactureViewModel obj)
        {
            throw new NotImplementedException();
        }
    }
}