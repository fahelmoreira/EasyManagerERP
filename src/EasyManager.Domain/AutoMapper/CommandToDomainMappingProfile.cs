using AutoMapper;
using EasyManager.Domain.Commands;
using EasyManager.Domain.Models;
using MediatR;
using Newtonsoft.Json;

namespace EasyManager.Domain.AutoMapper
{
    public class CommandToDomainMappingProfile : Profile
    {
        public CommandToDomainMappingProfile()
        {
            //Customer mapping
            CreateMap<CustomerCommand<Unit>, Customer>()
                .ForMember(c => c.Address, opt => opt.MapFrom(cmd => JsonConvert.SerializeObject(cmd.Address)))
                .ForMember(c => c.Contacts, opt => opt.MapFrom(cmd => JsonConvert.SerializeObject(cmd.Contacts)));

            //Manufactore mapping
            CreateMap<ManufactureCommand<Unit>, Manufacture>()
                .ForMember(c => c.Address, opt => opt.MapFrom(cmd => JsonConvert.SerializeObject(cmd.Address)))
                .ForMember(c => c.Contacts, opt => opt.MapFrom(cmd => JsonConvert.SerializeObject(cmd.Contacts)));

            //Bank account mapping
            CreateMap<BankAccountCommand<Unit>, BankAccount>()
                .ConstructUsing(b => new BankAccount(b.Bank));
            
            //Sales table item mapping
            CreateMap<SalesTableItemCommand<Unit>, SalesTable>();

            //Departament mapping
            CreateMap<DepartamentCommand<Unit>, Departament>();        

            // Category mapping
            CreateMap<CategoryCommand<Unit>, Category>()
                .ConstructUsing(ca => new Category(ca.ParentCategory));

            //Financial mapping
            CreateMap<FinancialCommand<Unit>, Financial>()
                .ForMember(c => c.PaymentMethod, opt => opt.MapFrom(cmd => new PaymentMethod{Id  = cmd.PaymentMethod}))
                .ForMember(c => c.InstallmentInformation, opt => opt.MapFrom(cmd => JsonConvert.SerializeObject(cmd.InstallmentInformation)));

            //Payment mapping
            CreateMap<PaymentMethodCommand<Unit>, PaymentMethod>()
                .ConvertUsing(cmd => new PaymentMethod(cmd.CredcardOperator, cmd.BankAccount));

            //Product mapping
            CreateMap<ProductCommand<Unit>, Product>()
                .ForMember(c => c.Category, opt => opt.MapFrom(cmd => new Category{Id = cmd.Category } ))
                .ForMember(c => c.Attributes, opt => opt.MapFrom(cmd => JsonConvert.SerializeObject(cmd.Attributes)))
                .ForMember(c => c.SalesTable, opt => opt.MapFrom(cmd => JsonConvert.SerializeObject(cmd.SalesTable)))
                .ForMember(c => c.Manufacture, opt => opt.MapFrom(cmd => new Manufacture{ Id = cmd.Manufacture }));

            //Order mapping
            CreateMap<OrderCommand<Unit>, Order>()
                .ForMember(c => c.Departament, opt => opt.MapFrom(cmd => new Departament{Id = cmd.Departament}))
                .ForMember(c => c.Customer, opt => opt.MapFrom(cmd => new Customer{ Id = cmd.Customer }))
                .ForMember(c => c.PaymentMethod, opt => opt.MapFrom(cmd => JsonConvert.SerializeObject(cmd.PaymentMethod)))
                .ForMember(c => c.ProductOrder, opt => opt.MapFrom(cmd => JsonConvert.SerializeObject(cmd.ProductOrder)));
            
            //Purchase mapping
            CreateMap<PurchaseCommand<Unit>, Purchase>()
                .ForMember(c => c.Manufacture, opt => opt.MapFrom(cmd => new Manufacture{Id = cmd.Manufacture}))
                .ForMember(c => c.PaymentMethod, opt => opt.MapFrom(cmd => JsonConvert.SerializeObject(cmd.PaymentMethod)));
        }
    }
}