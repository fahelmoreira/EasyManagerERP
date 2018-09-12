using AutoMapper;
using AutoMapper.Configuration;

namespace EasyManager.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static IMapperConfigurationExpression RegisterMappings()
        {
            var cfg = new MapperConfigurationExpression();
            cfg.AddProfile(new DomainToViewModelMappingProfile());
            cfg.AddProfile(new ViewModelToDomainMappingProfile());
            
            return cfg;
        }
    }
}