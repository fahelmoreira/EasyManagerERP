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
                .ConstructUsing(cmd => new Customer(cmd.Address, cmd.Contacts));

            //Manufactore mapping
            CreateMap<ManufactureCommand<Unit>, Manufacture>()
                .ConstructUsing(cmd => new Manufacture(cmd.Address, cmd.Contacts));

            //Bank account mapping
            CreateMap<BankAccountCommand<Unit>, BankAccount>()
                .ConstructUsing(b => new BankAccount(b.Bank));
            
            //Sales table item mapping
            CreateMap<SalesTableItemCommand<Unit>, SalesTable>();

            //Departament mapping
            CreateMap<DepartamentCommand<Unit>, Departament>();        

            // Category mapping
            CreateMap<CategoryCommand<Unit>, Category>()
                .ConstructUsing(cmd => new Category(cmd.ParentCategory));

            //Financial mapping
            CreateMap<FinancialCommand<Unit>, Financial>()
                .ConstructUsing(cmd => new Financial(cmd.PaymentMethod, cmd.InstallmentInformation));

            //Payment mapping
            CreateMap<PaymentMethodCommand<Unit>, PaymentMethod>()
                .ConvertUsing(cmd => new PaymentMethod(cmd.CredcardOperator, cmd.BankAccount));

            //Product mapping
            CreateMap<ProductCommand<Unit>, Product>()
                .ConstructUsing(cmd => new Product(cmd.Category, cmd.Manufacture, cmd.Attributes, cmd.SalesTable));

            //Order mapping
            CreateMap<OrderCommand<Unit>, Order>()
                .ConstructUsing(cmd => new Order(cmd.Departament, cmd.Customer, JsonConvert.SerializeObject(cmd.PaymentMethod), cmd.ProductOrder));
            
            //Purchase mapping
            CreateMap<PurchaseCommand<Unit>, Purchase>()
                .ConstructUsing(cmd => new Purchase(cmd.Manufacture, JsonConvert.SerializeObject(cmd.PaymentMethod), cmd.Products));
        }
    }
}