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
            CreateMap<CustomerCommand, CustomerRegisteredEvent>()
            .ForMember(ev => ev.AggregateId, opt => opt.MapFrom(c => c.Id));

            CreateMap<CustomerCommand, CustomerUpdatedEvent>()
            .ForMember(ev => ev.AggregateId, opt => opt.MapFrom(c => c.Id));
        }
    }
}