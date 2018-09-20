using EasyManager.Domain.Core.Bus;
using EasyManager.Domain.Core.Events;
using EasyManager.Infra.CrossCutting.Bus;
using EasyManager.Infra.Data.Context;
using EasyManager.Infra.Data.EventSourcing;
using EasyManager.Infra.Data.Repository.EventSourcing;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace EasyManager.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void AddEasyManager(this IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Application
            services.AddApplication();

            // Domain - Events
            services.AddEvents();

            // Domain - Commands
            services.AddCommands();

            // Infra - Data
            services.AddData();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSQLContext>();
        }
    }
}
