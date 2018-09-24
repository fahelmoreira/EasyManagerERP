using System;
using System.Linq;
using EasyManager.Domain.Interfaces;
using EasyManager.Domain.Models;
using EasyManager.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EasyManager.Infra.Data.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(EasyManagerContext context) : base(context)
        {
        }

        public int GetOrderStatus(Guid Id) => (int)DbSet.Where(x => x.Id == Id).AsNoTracking().FirstOrDefault().Status;
    }
}