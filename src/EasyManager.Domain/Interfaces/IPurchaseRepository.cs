using System;
using EasyManager.Domain.Models;

namespace EasyManager.Domain.Interfaces
{
    public interface IPurchaseRepository : IRepository<Purchase>
    {
        int GetOrderStatusById(Guid id);
    }
}