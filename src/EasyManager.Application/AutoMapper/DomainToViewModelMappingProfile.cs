using System;
using System.Collections.Generic;
using AutoMapper;
using EasyManager.Application.ViewModels;
using EasyManager.Domain.Models;
using Newtonsoft.Json;

namespace EasyManager.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile  : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            // Customer mapping
            CreateMap<Customer, CustomerShortViewModel>();
            CreateMap<Customer, CustomerViewModel>()
                .ForMember(cvm => cvm.Address, opt => opt.MapFrom(c =>  JsonConvert.DeserializeObject<Address>(c.Address)))
                .ForMember(cvm => cvm.Contacts, opt => opt.MapFrom(c => JsonConvert.DeserializeObject<List<Contact>>(c.Contacts)));

            // Manufacture mapping
            CreateMap<Manufacture, ManufactureShortViewModel>();
            CreateMap<Manufacture, ManufactureViewModel>()
                .ForMember(mvm => mvm.Address, opt => opt.MapFrom(m =>  JsonConvert.DeserializeObject<Address>(m.Address)))
                .ForMember(mvm => mvm.Contacts, opt => opt.MapFrom(m => JsonConvert.DeserializeObject<List<Contact>>(m.Contacts)));
            
            // Bank account mapping
            CreateMap<BankAccount, BankAccountShortViewModel>();
            CreateMap<BankAccount, BankAccountViewModel>()
                .ForMember(bvm => bvm.Bank, opt => opt.MapFrom(b => b.Bank.Id));
            
            // Bank mapping
            CreateMap<Bank, BankViewMode>();

            // Category mapping
            CreateMap<Category, CategoryViewModel>()
                .ForMember(ca => ca.ParentCategory, opt => opt.MapFrom(c => c.ParentCategory.Id ));

            // Credcard operator mappig
            CreateMap<CredcardOperator, CredcardOperatorViewModel>();

            // Departament mapping
            CreateMap<Departament, DepartamentViewModel>();

            // Financial mapping
            CreateMap<Financial, FinancialShortViewModel>();
            CreateMap<Financial, FinancialViewModel>()
                .ForMember(fvm => fvm.InstallmentInformation, opt => opt.MapFrom(f => JsonConvert.DeserializeObject<List<Installment>>(f.InstallmentInformation)))
                .ForMember(fvm => fvm.PaymentMethod, opt => opt.MapFrom(f => f.PaymentMethod.Id));

            // Order mapping
            CreateMap<Order, OrderShortViewModel>();
            CreateMap<Order, OrderViewModel>()
                .ForMember(ovm => ovm.Departament, opt => opt.MapFrom(o => o.Departament.Id))
                .ForMember(ovm => ovm.Customer, opt => opt.MapFrom(o => o.Customer.Id))
                .ForMember(ovm => ovm.ProductOrder, opt => opt.MapFrom(o => JsonConvert.DeserializeObject<List<ProductOrder> >(o.ProductOrder)));

            // Payment method mapping
            CreateMap<PaymentMethod, PaymentMethodShotViewModel>();
            CreateMap<PaymentMethod, PaymentMethodViewModel>()
                .ForMember(pvm => pvm.BankAccount, opt => opt.MapFrom(p => p.BankAccount.Id))
                .ForMember(pvm => pvm.CredcardOperator, opt => opt.MapFrom(p => p.CredcardOperator.Id));

            // Product mapping
            CreateMap<Product, ProductShortViewModel>();
            CreateMap<Product, ProductViewModel>()
                .ForMember(pvm => pvm.Category, opt => opt.MapFrom(p => p.Category.Id))
                .ForMember(pvm => pvm.SalesTable, opt => opt.MapFrom(p => JsonConvert.DeserializeObject<List<SalesTableViewModel>>(p.SalesTable)))
                .ForMember(pvm => pvm.Attributes, opt => opt.MapFrom(p => JsonConvert.DeserializeObject<List<Attribute>>(p.Attributes)))
                .ForMember(pvm => pvm.Bundles, opt => opt.MapFrom(p => p.Bundles));
            
            // Purchase mapping
            CreateMap<Purchase, PurchaseShortViewModel>();
            CreateMap<Purchase, PurchaseViewModel>()
                .ForMember(pvm => pvm.Manufacture, opt => opt.MapFrom(p => p.Manufacture.Id));

            // Sales table view model
            CreateMap<SalesTable, SalesTableViewModel>();
        }
    }
}