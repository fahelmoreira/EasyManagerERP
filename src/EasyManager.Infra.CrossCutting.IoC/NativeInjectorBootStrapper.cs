using EasyManager.Domain.CommandHandlers;
using EasyManager.Domain.Commands;
using EasyManager.Domain.Core.Bus;
using EasyManager.Domain.Core.Events;
using EasyManager.Domain.Core.Notifications;
using EasyManager.Domain.EventHandlers;
using EasyManager.Domain.Events;
using EasyManager.Domain.Interfaces;
using EasyManager.Infra.CrossCutting.Bus;
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

        }
    }
}
