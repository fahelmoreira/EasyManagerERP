using System;
using EasyManager.Domain.CommandHandlers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace EasyManager.WebAPI.Configurations
{
    /// <summary>
    /// Sets up the mediator
    /// </summary>
    public static class MediatorSetup
    {
        /// <summary>
        /// Add the mediator dependecies
        /// </summary>
        public static void AddMediatorSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddMediatR(typeof(Startup).Assembly, typeof(CommandHandler).Assembly);            
        }
    }
}