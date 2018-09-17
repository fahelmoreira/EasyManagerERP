using System;
using AutoMapper;
using EasyManager.Application.ViewModels;
using EasyManager.Domain.Commands;

namespace EasyManager.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            //Customer mapping
            CreateMap<CustomerViewModel, RegisterNewCustomerCommand>()
            .ForMember(cmd => cmd.AggregateId, opt => opt.MapFrom(c => c.Id));
            CreateMap<CustomerViewModel, UpdateCustomerCommand>()
            .ForMember(cmd => cmd.AggregateId, opt => opt.MapFrom(c => c.Id));
            CreateMap<Guid, RemoveCustomerCommand>()
            .ConstructUsing(id => new RemoveCustomerCommand(id));

            //Manufacure mapping
            CreateMap<ManufactureViewModel, RegisterNewManufactureCommand>()
            .ForMember(m => m.AggregateId, opt => opt.MapFrom(c => c.Id));
            CreateMap<ManufactureViewModel, UpdateManufactureCommand>()
            .ForMember(m => m.AggregateId, opt => opt.MapFrom(c => c.Id));
            CreateMap<Guid, RemoveManufactureCommand>()
            .ConstructUsing(id => new RemoveManufactureCommand(id));
        }
    }
}