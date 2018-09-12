using System;
using AutoMapper;
using EasyManager.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace EasyManager.WebAPI.Configurations
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
      {
          if (services == null) throw new ArgumentNullException(nameof(services));

          // Registering Mappings automatically only works if the 
          // Automapper Profile classes are in ASP.NET project
          var cfg = AutoMapperConfig.RegisterMappings();

          services.AddAutoMapper();

          Mapper.Initialize(configuration => configuration = cfg );
      }
    }
}