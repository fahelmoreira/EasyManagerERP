using AutoMapper;
using EasyManager.Domain.Commands;
using EasyManager.Domain.Events;
using EasyManager.Domain.Models;

namespace EasyManager.Domain.AutoMapper
{
    public class CommandToEventMappingProfile : Profile
    {
        public CommandToEventMappingProfile()
        {
            //Customer mapping
            CreateMap<CustomerCommand, CustomerRegisteredEvent>()
                .ForMember(ev => ev.AggregateId, opt => opt.MapFrom(c => c.Id));
            CreateMap<CustomerCommand, CustomerUpdatedEvent>()
                .ForMember(ev => ev.AggregateId, opt => opt.MapFrom(c => c.Id));

            //Manufactore mapping
            CreateMap<ManufactureCommand, ManufactureRegisteredEvent>()
                .ForMember(ev => ev.AggregateId, opt => opt.MapFrom(c => c.Id));
            CreateMap<ManufactureCommand, ManufactureUpdatedEvent>()
                .ForMember(ev => ev.AggregateId, opt => opt.MapFrom(c => c.Id));
                
            // Bank account mapping
            CreateMap<BankAccountCommand, BankAccountRegisteredEvent>()
                .ForMember(ev => ev.AggregateId, opt => opt.MapFrom(c => c.Id));
            CreateMap<BankAccountCommand, BankAccountUpdatedEvent>()
                .ForMember(ev => ev.AggregateId, opt => opt.MapFrom(c => c.Id));
        }
    }
}