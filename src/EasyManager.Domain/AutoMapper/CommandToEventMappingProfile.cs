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
            CreateMap<RegisterNewCustomerCommand, CustomerRegisteredEvent>()
                .ForMember(ev => ev.AggregateId, opt => opt.MapFrom(c => c.Id));
            CreateMap<UpdateCustomerCommand, CustomerUpdatedEvent>()
                .ForMember(ev => ev.AggregateId, opt => opt.MapFrom(c => c.Id));
            CreateMap<RemoveCustomerCommand, CustomerRemovedEvent>()
                .ConstructUsing(ev => new CustomerRemovedEvent(ev.Id));

            //Manufactore mapping
            CreateMap<RegisterNewManufactureCommand, ManufactureRegisteredEvent>()
                .ForMember(ev => ev.AggregateId, opt => opt.MapFrom(c => c.Id));
            CreateMap<UpdateManufactureCommand, ManufactureUpdatedEvent>()
                .ForMember(ev => ev.AggregateId, opt => opt.MapFrom(c => c.Id));
            CreateMap<RemoveManufactureCommand, ManufactureRemovedEvent>()
                .ConstructUsing(ev => new ManufactureRemovedEvent(ev.Id));
                
            // Bank account mapping
            CreateMap<RegisterNewBankAccountCommand, BankAccountRegisteredEvent>()
                .ForMember(ev => ev.AggregateId, opt => opt.MapFrom(c => c.Id));
            CreateMap<UpdateBankAccountCommand, BankAccountUpdatedEvent>()
                .ForMember(ev => ev.AggregateId, opt => opt.MapFrom(c => c.Id));
            CreateMap<RemoveBankAccountCommand, BankAccountRemovedEvent>()
                .ConstructUsing(ev => new BankAccountRemovedEvent(ev.Id));

            // Sales table item mapping
            CreateMap<RegisterNewSalesTableItemCommand, SalesTableItemRegisteredEvent>()
                .ForMember(ev => ev.AggregateId, opt => opt.MapFrom(c => c.Id));
            CreateMap<UpdateSalesTableItemCommand, SalesTableItemUpdatedEvent>()
                .ForMember(ev => ev.AggregateId, opt => opt.MapFrom(c => c.Id));
            CreateMap<RemoveSalesTableItemCommand, SalesTableItemRemovedEvent>()
                .ConstructUsing(ev => new SalesTableItemRemovedEvent(ev.Id));
            
            // Departament mapping
            CreateMap<RegisterNewDepartamentCommand, DepartamentRegisteredEvent>()
                .ForMember(ev => ev.AggregateId, opt => opt.MapFrom(c => c.Id));
            CreateMap<UpdateDepartamentCommand, DepartamentUpdatedEvent>()
                .ForMember(ev => ev.AggregateId, opt => opt.MapFrom(c => c.Id));
            CreateMap<RemoveDepartamentCommand, DepartamentRemovedEvent>()
                .ConstructUsing(ev => new DepartamentRemovedEvent(ev.Id));
        }
    }
}