using AutoMapper;
using EasyManager.Application.ViewModels;
using EasyManager.Domain.Commands;

namespace EasyManager.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CustomerViewModel, RegisterNewCustomerCommand>()
                .ConstructUsing(
                    c => new RegisterNewCustomerCommand(
                        c.TradeName, 
                        c.Type.Value,
                        c.IndividualTaxpayerId, 
                        c.CorporateTaxpayerId, 
                        c.Address, 
                        c.Contacts
                    )
                );

            CreateMap<CustomerViewModel, UpdateCustomerCommand>()
                .ConstructUsing(
                    c => new UpdateCustomerCommand(
                        c.Id,
                        c.TradeName, 
                        c.Type.Value,
                        c.IndividualTaxpayerId, 
                        c.CorporateTaxpayerId, 
                        c.Address, 
                        c.Contacts
                    )
                );
        }
    }
}