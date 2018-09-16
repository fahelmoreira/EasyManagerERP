using EasyManager.Domain.Core.Notifications;
using EasyManager.Domain.EventHandlers;
using EasyManager.Domain.Events;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace EasyManager.Infra.CrossCutting.IoC
{
    public static class EventsDependecies
    {
        internal static void AddEvents(this IServiceCollection services)
        {
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            services.AddScoped<INotificationHandler<CustomerRegisteredEvent>, CustomerEventHandler>();
            services.AddScoped<INotificationHandler<CustomerUpdatedEvent>, CustomerEventHandler>();
            services.AddScoped<INotificationHandler<CustomerRemovedEvent>, CustomerEventHandler>();

            services.AddScoped<INotificationHandler<ManufactureRegisteredEvent>, ManufactureEventHandler>();
            services.AddScoped<INotificationHandler<ManufactureRemovedEvent>, ManufactureEventHandler>();
            services.AddScoped<INotificationHandler<ManufactureUpdatedEvent>, ManufactureEventHandler>(); 

            services.AddScoped<INotificationHandler<ProductRegisteredEvent>, ProductEventHandler>();
            services.AddScoped<INotificationHandler<ProductRemovedEvent>, ProductEventHandler>();
            services.AddScoped<INotificationHandler<ProductUpdatedEvent>, ProductEventHandler>();

            services.AddScoped<INotificationHandler<SalesTableItemRegisteredEvent>, SalesTableEventHandler>();
            services.AddScoped<INotificationHandler<SalesTableItemRemovedEvent>, SalesTableEventHandler>();
            services.AddScoped<INotificationHandler<SalesTableItemUpdatedEvent>, SalesTableEventHandler>();

            services.AddScoped<INotificationHandler<CategoryRegisteredEvent>, CategoryEventHandler>();
            services.AddScoped<INotificationHandler<CategoryRemovedEvent>, CategoryEventHandler>();
            services.AddScoped<INotificationHandler<CategoryUpdatedEvent>, CategoryEventHandler>();

            services.AddScoped<INotificationHandler<BankAccountRegisteredEvent>, BankAccountEventHandler>();
            services.AddScoped<INotificationHandler<BankAccountRemovedEvent>, BankAccountEventHandler>();
            services.AddScoped<INotificationHandler<BankAccountUpdatedEvent>, BankAccountEventHandler>();

            services.AddScoped<INotificationHandler<DepartamentRegisteredEvent>, DepartamentEventHandler>();
            services.AddScoped<INotificationHandler<DepartamentRemovedEvent>, DepartamentEventHandler>();
            services.AddScoped<INotificationHandler<DepartamentUpdatedEvent>, DepartamentEventHandler>();

            services.AddScoped<INotificationHandler<FinancialRegisteredEvent>, FinancialEventHandler>();
            services.AddScoped<INotificationHandler<FinancialRemovedEvent>, FinancialEventHandler>();
            services.AddScoped<INotificationHandler<FinancialUpdatedEvent>, FinancialEventHandler>();

            services.AddScoped<INotificationHandler<OrderRegisteredEvent>, OrderEventHandler>();
            services.AddScoped<INotificationHandler<OrderRemovedEvent>, OrderEventHandler>();
            services.AddScoped<INotificationHandler<OrderUpdatedEvent>, OrderEventHandler>();

            services.AddScoped<INotificationHandler<PaymentMethodRegisteredEvent>, PaymentMethodEventHandler>();
            services.AddScoped<INotificationHandler<PaymentMethodRemovedEvent>, PaymentMethodEventHandler>();
            services.AddScoped<INotificationHandler<PaymentMethodUpdatedEvent>, PaymentMethodEventHandler>();

            services.AddScoped<INotificationHandler<PurchaseRegisteredEvent>, PurchaseEventHandler>();
            services.AddScoped<INotificationHandler<PurchaseRemovedEvent>, PurchaseEventHandler>();
            services.AddScoped<INotificationHandler<PurchaseUpdatedEvent>, PurchaseEventHandler>();
        }
    }
}