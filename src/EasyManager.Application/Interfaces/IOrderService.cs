using EasyManager.Application.ViewModels;

namespace EasyManager.Application.Interfaces
{
    public interface IOrderService : IAppServices<OrderViewModel, OrderShortViewModel>
    {
        
    }
}