using EasyManager.Application.Interfaces;
using EasyManager.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EasyManager.Infra.CrossCutting.IoC
{
    public static class ApplicationDependecies
    {
        internal static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICustomerAppService, CustomerAppService>();
            services.AddScoped<IManufactureAppServices, ManufactureAppServices>();
            services.AddScoped<IBankAccountAppService, BankAccountAppService>();
            services.AddScoped<ICategoryAppService, CategoryAppService>();
            services.AddScoped<IDepartamentAppService, DepartamentAppService>();
            services.AddScoped<IFinancialAppService, FinancialAppService>();
            services.AddScoped<IOrderAppService, OrderAppService>();
            services.AddScoped<IPaymentMethodAppService, PaymentMethodAppService>();
            services.AddScoped<IProductAppService, ProductAppService>();
            services.AddScoped<IPurchaseAppService, PurchaseAppService>();
            services.AddScoped<ISalesTableAppService, SalesTableAppService>();
        }
    }
}