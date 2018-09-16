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

            // Financial mapping
            CreateMap<RegisterNewFinancialCommand, FinancialRegisteredEvent>()
                .ForMember(ev => ev.AggregateId, opt => opt.MapFrom(c => c.Id));
            CreateMap<UpdateFinancialCommand, FinancialUpdatedEvent>()
                .ForMember(ev => ev.AggregateId, opt => opt.MapFrom(c => c.Id));
            CreateMap<RemoveFinancialCommand, FinancialRemovedEvent>()
                .ConstructUsing(ev => new FinancialRemovedEvent(ev.Id));
            
            // Payment mapping
            CreateMap<RegisterNewPaymentMethodCommand, PaymentMethodRegisteredEvent>()
                .ForMember(ev => ev.AggregateId, opt => opt.MapFrom(c => c.Id));
            CreateMap<UpdatePaymentMethodCommand, PaymentMethodUpdatedEvent>()
                .ForMember(ev => ev.AggregateId, opt => opt.MapFrom(c => c.Id));
            CreateMap<RemovePaymentMethodCommand, PaymentMethodRemovedEvent>()
                .ConstructUsing(ev => new PaymentMethodRemovedEvent(ev.Id));

            // Payment mapping
            CreateMap<RegisterNewPaymentMethodCommand, PaymentMethodRegisteredEvent>()
                .ForMember(ev => ev.AggregateId, opt => opt.MapFrom(c => c.Id));
            CreateMap<UpdatePaymentMethodCommand, PaymentMethodUpdatedEvent>()
                .ForMember(ev => ev.AggregateId, opt => opt.MapFrom(c => c.Id));
            CreateMap<RemovePaymentMethodCommand, PaymentMethodRemovedEvent>()
                .ConstructUsing(ev => new PaymentMethodRemovedEvent(ev.Id));
            
            // Product mapping
            CreateMap<RegisterNewProductCommand, ProductRemovedEvent>()
                .ForMember(ev => ev.AggregateId, opt => opt.MapFrom(c => c.Id));
            CreateMap<UpdateProductCommand, ProductUpdatedEvent>()
                .ForMember(ev => ev.AggregateId, opt => opt.MapFrom(c => c.Id));
            CreateMap<RemoveProductCommand, ProductRemovedEvent>()
                .ConstructUsing(ev => new ProductRemovedEvent(ev.Id));

            // Order mapping
            CreateMap<RegisterNewOrderCommand, OrderRegisteredEvent>()
                .ForMember(ev => ev.AggregateId, opt => opt.MapFrom(c => c.Id));
            CreateMap<UpdateOrderCommand, OrderUpdatedEvent>()
                .ForMember(ev => ev.AggregateId, opt => opt.MapFrom(c => c.Id));
            CreateMap<RemoveOrderCommand, OrderRemovedEvent>()
                .ConstructUsing(ev => new OrderRemovedEvent(ev.Id));
        }
    }
}