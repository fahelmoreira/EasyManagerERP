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
            .ForMember(cmd => cmd.AggregateId, opt => opt.MapFrom(c => c.Id));
            
            CreateMap<CustomerViewModel, UpdateCustomerCommand>()
            .ForMember(cmd => cmd.AggregateId, opt => opt.MapFrom(c => c.Id));;
        }
    }
}