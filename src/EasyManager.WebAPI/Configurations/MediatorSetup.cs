using System;
using EasyManager.Domain.CommandHandlers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace EasyManager.WebAPI.Configurations
{
    public static class MediatorSetup
    {
        public static void AddMediatorSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddMediatR(typeof(Startup).Assembly, typeof(CommandHandler).Assembly);            
        }
    }
}