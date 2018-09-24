using System;
using System.Linq;
using EasyManager.Domain.Interfaces;
using EasyManager.Domain.Models;
using EasyManager.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EasyManager.Infra.Data.Repository
{
    public class PurchaseRepository : Repository<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(EasyManagerContext context) : base(context)
        {
        }

        public int GetOrderStatusById(Guid id) => (int)DbSet.Where(x => x.Id == id).AsNoTracking().FirstOrDefault().Status;
    }
}