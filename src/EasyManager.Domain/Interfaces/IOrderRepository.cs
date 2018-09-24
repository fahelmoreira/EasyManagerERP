using System;
using EasyManager.Domain.Models;

namespace EasyManager.Domain.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
         int GetOrderStatus(Guid Id);
    }
}