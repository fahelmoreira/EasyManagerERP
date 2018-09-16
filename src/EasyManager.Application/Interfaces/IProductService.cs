using EasyManager.Application.ViewModels;

namespace EasyManager.Application.Interfaces
{
    public interface IProductService : IAppServices<ProductViewModel, ProductShortViewModel>
    {
         
    }
}