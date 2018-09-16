using EasyManager.Application.ViewModels;

namespace EasyManager.Application.Interfaces
{
    public interface IBankAccountService : IAppServices<BankAccountViewModel, BankAccountShort>
    {
        
    }
}