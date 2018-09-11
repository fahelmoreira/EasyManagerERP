using EasyManager.Domain.CommandHandlers;
using EasyManager.Domain.Commands;
using EasyManager.Domain.Core.Bus;
using EasyManager.Domain.Core.Events;
using EasyManager.Domain.Core.Notifications;
using EasyManager.Domain.EventHandlers;
using EasyManager.Domain.Events;
using EasyManager.Domain.Interfaces;
using EasyManager.Infra.CrossCutting.Bus;
using EasyManager.Infra.Data.Context;
using EasyManager.Infra.Data.EventSourcing;
using EasyManager.Infra.Data.Repository;
using EasyManager.Infra.Data.Repository.EventSourcing;
using EasyManager.Infra.Data.UoW;
using MediatR;
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

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<CustomerRegisteredEvent>, CustomerEventHandler>();
            services.AddScoped<INotificationHandler<CustomerUpdatedEvent>, CustomerEventHandler>();
            services.AddScoped<INotificationHandler<CustomerRemovedEvent>, CustomerEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewCustomerCommand>, CustomerCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCustomerCommand>, CustomerCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveCustomerCommand>, CustomerCommandHandler>();

            // Infra - Data
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<EasyManagerContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSQLContext>();

        }
    }
}
