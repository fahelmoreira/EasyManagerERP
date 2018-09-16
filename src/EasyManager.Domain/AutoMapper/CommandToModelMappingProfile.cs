using AutoMapper;
using EasyManager.Domain.Commands;
using EasyManager.Domain.Models;
using MediatR;
using Newtonsoft.Json;

namespace EasyManager.Domain.AutoMapper
{
    public class CommandToModelMappingProfile : Profile
    {
        public CommandToModelMappingProfile()
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
                .ForMember(b => b.Bank, opt => opt.MapFrom(x => new BankAccount{ Id = x.Bank }));
            
            //Sales table item mapping
            CreateMap<SalesTableItemCommand<Unit>, SalesTable>();

            //Departament mapping
            CreateMap<DepartamentCommand<Unit>, Departament>();          

            //Financial mapping
            CreateMap<FinancialCommand<Unit>, Financial>()
                .ForMember(c => c.InstallmentInformation, opt => opt.MapFrom(cmd => JsonConvert.SerializeObject(cmd.InstallmentInformation)));

            //Payment mapping
            CreateMap<PaymentMethodCommand<Unit>, PaymentMethod>()
                .ForMember(c => c.BankAccount, opt => opt.MapFrom(cmd => new BankAccount{Id = cmd.BankAccount }))
                .ForMember(c => c.CredcardOperator, opt => opt.MapFrom(cmd => new CredcardOperator{Id = cmd.CredcardOperator }));

            //Product mapping
            CreateMap<ProductCommand<Unit>, Product>()
                .ForMember(c => c.Category, opt => opt.MapFrom(cmd => new Category{Id = cmd.Category }))
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