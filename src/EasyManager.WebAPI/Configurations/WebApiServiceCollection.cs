using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace EasyManager.WebAPI.Configurations
{
    /// <summary>
    /// Setup API services collection
    /// </summary>
    public static class WebApiServiceCollection
    {
        /// <summary>
        /// Add webapi dependecies
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IMvcBuilder AddWebApi(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            var builder = services.AddMvcCore();
            builder.AddJsonFormatters();
            builder.AddApiExplorer();
            builder.AddCors();

            return new MvcBuilder(builder.Services, builder.PartManager);
        }

        /// <summary>
        /// Add webapi dependecies
        /// </summary>
        public static IMvcBuilder AddWebApi(this IServiceCollection services, Action<MvcOptions> setupAction)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            if (setupAction == null) throw new ArgumentNullException(nameof(setupAction));

            var builder = services.AddWebApi();
            builder.Services.Configure(setupAction);

            return builder;
        }

    }
}