using System;
using AutoMapper;
using AutoMapper.Configuration;
using EasyManager.Application.AutoMapper;
using EasyManager.Domain.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace EasyManager.WebAPI.Configurations
{
    /// <summary>
    /// Class that set up automapper
    /// </summary>
    public static class AutoMapperSetup
    {
        /// <summary>
        /// Adds autoMapper dependecies 
        /// </summary>
        public static void AddAutoMapperSetup(this IServiceCollection services)
      {
          if (services == null) throw new ArgumentNullException(nameof(services));

          // Registering Mappings automatically only works if the 
          // Automapper Profile classes are in ASP.NET project
          var cfg = new MapperConfigurationExpression();

          // Aplications mapping profiles
          cfg.AddProfiles(typeof(ApplicationAutoMapperConfig).Assembly);
          cfg.AddProfiles(typeof(DomainAutoMapperConfig).Assembly);

          services.AddAutoMapper();

          Mapper.Initialize(configuration => configuration = cfg );
      }
    }
}