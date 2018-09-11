using System;
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
            CreateMap<Customer, CustomerViewModel>()
            .ForMember(cvm => cvm.Address, opt => opt.MapFrom(c => JsonConvert.DeserializeObject<Address>(c.Address)))
            .ForMember(cvm => cvm.Contacts, opt => opt.MapFrom(c => JsonConvert.DeserializeObject<Contact>(c.Contacts)));
        }
    }
}