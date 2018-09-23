using System;
using AutoMapper;
using EasyManager.Application.ViewModels;
using EasyManager.Domain.Commands;

namespace EasyManager.Application.AutoMapper
{
    public class ViewModelToCommandMappingProfile : Profile
    {
        public ViewModelToCommandMappingProfile()
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

            // Bank account mapping
            CreateMap<BankAccountViewModel, RegisterNewBankAccountCommand>()
                .ForMember(cmd => cmd.AggregateId, opt => opt.MapFrom(c => c.Id));
             CreateMap<BankAccountViewModel, UpdateBankAccountCommand>()
                .ForMember(m => m.AggregateId, opt => opt.MapFrom(c => c.Id));
            CreateMap<Guid, RemoveBankAccountCommand>()
                .ConstructUsing(id => new RemoveBankAccountCommand(id));

            // Category mapping
            CreateMap<CategoryViewModel, RegisterNewCategoryCommand>()
                .ForMember(cmd => cmd.AggregateId, opt => opt.MapFrom(c => c.Id));
             CreateMap<CategoryViewModel, UpdateCategoryCommand>()
                .ForMember(m => m.AggregateId, opt => opt.MapFrom(c => c.Id));
            CreateMap<Guid, RemoveCategoryCommand>()
                .ConstructUsing(id => new RemoveCategoryCommand(id));

            // Departament mapping
            CreateMap<DepartamentViewModel, RegisterNewDepartamentCommand>()
                .ForMember(cmd => cmd.AggregateId, opt => opt.MapFrom(c => c.Id));
             CreateMap<DepartamentViewModel, UpdateDepartamentCommand>()
                .ForMember(m => m.AggregateId, opt => opt.MapFrom(c => c.Id));
            CreateMap<Guid, RemoveDepartamentCommand>()
                .ConstructUsing(id => new RemoveDepartamentCommand(id));

            // Financial mapping
            CreateMap<FinancialViewModel, RegisterNewFinancialCommand>()
                .ForMember(cmd => cmd.AggregateId, opt => opt.MapFrom(c => c.Id));
             CreateMap<FinancialViewModel, UpdateFinancialCommand>()
                .ForMember(m => m.AggregateId, opt => opt.MapFrom(c => c.Id));
            CreateMap<Guid, RemoveFinancialCommand>()
                .ConstructUsing(id => new RemoveFinancialCommand(id));

            // Order mapping
            CreateMap<OrderViewModel, RegisterNewOrderCommand>()
                .ForMember(cmd => cmd.AggregateId, opt => opt.MapFrom(c => c.Id));
             CreateMap<OrderViewModel, UpdateOrderCommand>()
                .ForMember(m => m.AggregateId, opt => opt.MapFrom(c => c.Id));
            CreateMap<Guid, RemoveOrderCommand>()
                .ConstructUsing(id => new RemoveOrderCommand(id));

            // Payment method mapping
            CreateMap<PaymentMethodViewModel, RegisterNewPaymentMethodCommand>()
                .ForMember(cmd => cmd.AggregateId, opt => opt.MapFrom(c => c.Id));
             CreateMap<PaymentMethodViewModel, UpdatePaymentMethodCommand>()
                .ForMember(m => m.AggregateId, opt => opt.MapFrom(c => c.Id));
            CreateMap<Guid, RemovePaymentMethodCommand>()
                .ConstructUsing(id => new RemovePaymentMethodCommand(id));

            // Product mapping
            CreateMap<ProductViewModel, RegisterNewProductCommand>()
                .ForMember(cmd => cmd.AggregateId, opt => opt.MapFrom(c => c.Id));
             CreateMap<ProductViewModel, UpdateDepartamentCommand>()
                .ForMember(m => m.AggregateId, opt => opt.MapFrom(c => c.Id));
            CreateMap<Guid, RemoveProductCommand>()
                .ConstructUsing(id => new RemoveProductCommand(id));

            // Product mapping
            CreateMap<PurchaseViewModel, RegisterNewPurchaseCommand>()
                .ForMember(cmd => cmd.AggregateId, opt => opt.MapFrom(c => c.Id));
             CreateMap<PurchaseViewModel, UpdatePurchaseCommand>()
                .ForMember(m => m.AggregateId, opt => opt.MapFrom(c => c.Id));
            CreateMap<Guid, RemovePurchaseCommand>()
                .ConstructUsing(id => new RemovePurchaseCommand(id));
            
            // SalesTable mapping
            CreateMap<SalesTableViewModel, RegisterNewSalesTableItemCommand>()
                .ForMember(cmd => cmd.AggregateId, opt => opt.MapFrom(c => c.Id));
             CreateMap<SalesTableViewModel, UpdateSalesTableItemCommand>()
                .ForMember(m => m.AggregateId, opt => opt.MapFrom(c => c.Id));
            CreateMap<Guid, RemoveSalesTableItemCommand>()
                .ConstructUsing(id => new RemoveSalesTableItemCommand(id));

        }
    }
}