using EasyManager.Domain.Interfaces;
using EasyManager.Infra.Data.Context;
using EasyManager.Infra.Data.Repository;
using EasyManager.Infra.Data.UoW;
using Microsoft.Extensions.DependencyInjection;

namespace EasyManager.Infra.CrossCutting.IoC
{
    public static class DataDependecies
    {
        internal static void AddData(this IServiceCollection services)
        {
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
        }
    }
}