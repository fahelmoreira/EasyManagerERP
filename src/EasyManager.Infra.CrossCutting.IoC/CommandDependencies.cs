using EasyManager.Domain.CommandHandlers;
using EasyManager.Domain.Commands;
using EasyManager.Domain.Core.Units;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace EasyManager.Infra.CrossCutting.IoC
{
    public static class CommandDependencies
    {
        internal static void AddCommands(this IServiceCollection services)
        {
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
        }
    }
}