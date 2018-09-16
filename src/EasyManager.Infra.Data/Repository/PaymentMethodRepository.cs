using EasyManager.Domain.Interfaces;
using EasyManager.Domain.Models;

namespace EasyManager.Infra.Data.Repository
{
    public class PaymentMethodRepository : Repository<PaymentMethod>, IPaymentMethodRepository
    {
        
    }
}