using System;
using EasyManager.Domain.Models;

namespace EasyManager.Domain.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
         int GetOrderStatusById(Guid Id);
    }
}