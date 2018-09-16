using EasyManager.Application.Interfaces;
using EasyManager.Application.Services;
using EasyManager.Domain.CommandHandlers;
using EasyManager.Domain.Commands;
using EasyManager.Domain.Core.Bus;
using EasyManager.Domain.Core.Events;
using EasyManager.Domain.Core.Notifications;
using EasyManager.Domain.Core.Units;
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

            // Application
            services.AddScoped<ICustomerAppService, CustomerAppService>();
            services.AddScoped<IManufactureAppServices, ManufactureAppServices>();

            // Domain - Events
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

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewCustomerCommand, RegisterUnit>, CustomerCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveCustomerCommand, RemoveUnit>, CustomerCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCustomerCommand, UpdateUnit>, CustomerCommandHandler>();
            
            services.AddScoped<IRequestHandler<RegisterNewManufactureCommand, RegisterUnit>, ManufactureCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveManufactureCommand, RemoveUnit>, ManufactureCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateManufactureCommand, UpdateUnit>, ManufactureCommandHandler>();
            
            services.AddScoped<IRequestHandler<RegisterNewProductCommand, RegisterUnit>, ProductCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveProductCommand, RemoveUnit>, ProductCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateProductCommand, UpdateUnit>, ProductCommandHandler>();

            services.AddScoped<IRequestHandler<RegisterNewSalesTableItemCommand, RegisterUnit>, SalesTableCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveSalesTableItemCommand, RemoveUnit>, SalesTableCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateSalesTableItemCommand, UpdateUnit>, SalesTableCommandHandler>();

            services.AddScoped<IRequestHandler<RegisterNewCategoryCommand, RegisterUnit>, CategoryCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveCategoryCommand, RemoveUnit>, CategoryCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCategoryCommand, UpdateUnit>, CategoryCommandHandler>();

            services.AddScoped<IRequestHandler<RegisterNewBankAccountCommand, RegisterUnit>, BankAccountCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveBankAccountCommand, RemoveUnit>, BankAccountCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateBankAccountCommand, UpdateUnit>, BankAccountCommandHandler>();

            services.AddScoped<IRequestHandler<RegisterNewDepartamentCommand, RegisterUnit>, DepartamentCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveDepartamentCommand, RemoveUnit>, DepartamentCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateDepartamentCommand, UpdateUnit>, DepartamentCommandHandler>();

            services.AddScoped<IRequestHandler<RegisterNewFinancialCommand, RegisterUnit>, FinancialCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveFinancialCommand, RemoveUnit>, FinancialCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateFinancialCommand, UpdateUnit>, FinancialCommandHandler>();

            services.AddScoped<IRequestHandler<RegisterNewOrderCommand, RegisterUnit>, OrderCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveOrderCommand, RemoveUnit>, OrderCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateOrderCommand, UpdateUnit>, OrderCommandHandler>();

            services.AddScoped<IRequestHandler<RegisterNewPaymentMethodCommand, RegisterUnit>, PaymentMethodCommandHandler>();
            services.AddScoped<IRequestHandler<RemovePaymentMethodCommand, RemoveUnit>, PaymentMethodCommandHandler>();
            services.AddScoped<IRequestHandler<UpdatePaymentMethodCommand, UpdateUnit>, PaymentMethodCommandHandler>();

            services.AddScoped<IRequestHandler<RegisterNewPurchaseCommand, RegisterUnit>, PurchaseCommandHandler>();
            services.AddScoped<IRequestHandler<RemovePurchaseCommand, RemoveUnit>, PurchaseCommandHandler>();
            services.AddScoped<IRequestHandler<UpdatePurchaseCommand, UpdateUnit>, PurchaseCommandHandler>();

            // Infra - Data
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IManufactureRepository, ManufactureRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ISalesTableRepository, SalesTableRepository>();
            services.AddScoped<ICaregoryRepository, CategoryRepository>();
            services.AddScoped<IBankAccountRepository, BankAccountRepository>();
            services.AddScoped<IDepartamentRepository, DepartamentRepository>();
            services.AddScoped<IFinancialRepository, FinancialRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IPaymentMethodRepository, PaymentMethodRepository>();
            services.AddScoped<IPurchaseRepository, PurchaseRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<EasyManagerContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSQLContext>();

        }
    }
}
