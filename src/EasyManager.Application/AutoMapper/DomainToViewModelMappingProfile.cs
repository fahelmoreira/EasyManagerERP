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
            //Customer mapping
            CreateMap<Customer, CustomerShortViewModel>();
            CreateMap<Customer, CustomerViewModel>()
                .ForMember(cvm => cvm.Address, opt => opt.MapFrom(c =>  JsonConvert.DeserializeObject<Address>(c.Address)))
                .ForMember(cvm => cvm.Contacts, opt => opt.MapFrom(c => JsonConvert.DeserializeObject<List<Contact>>(c.Contacts)));

            // Manufacture mapping
            CreateMap<Manufacture, ManufactureShortViewModel>();
            CreateMap<Manufacture, ManufactureViewModel>()
                .ForMember(m => m.Address, opt => opt.MapFrom(c =>  JsonConvert.DeserializeObject<Address>(c.Address)))
                .ForMember(m => m.Contacts, opt => opt.MapFrom(c => JsonConvert.DeserializeObject<List<Contact>>(c.Contacts)));
        }
    }
}