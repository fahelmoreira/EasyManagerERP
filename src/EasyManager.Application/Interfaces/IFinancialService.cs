using EasyManager.Application.ViewModels;

namespace EasyManager.Application.Interfaces
{
    public interface IFinancialService : IAppServices<FinancialViewModel, FinancialShortViewModel>
    {
        
    }
}