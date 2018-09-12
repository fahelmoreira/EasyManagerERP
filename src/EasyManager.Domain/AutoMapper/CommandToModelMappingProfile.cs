using AutoMapper;
using EasyManager.Domain.Commands;
using EasyManager.Domain.Models;
using Newtonsoft.Json;

namespace EasyManager.Domain.AutoMapper
{
    public class CommandToModelMappingProfile : Profile
    {
        public CommandToModelMappingProfile()
        {
            CreateMap<CustomerCommand, Customer>()
            .ForMember(c => c.Address, opt => opt.MapFrom(cmd => JsonConvert.SerializeObject(cmd.Address)))
            .ForMember(c => c.Contacts, opt => opt.MapFrom(cmd => JsonConvert.SerializeObject(cmd.Contacts)));
        }
    }
}