using System;
using System.Linq;
using EasyManager.Domain.Interfaces;
using EasyManager.Domain.Models;
using EasyManager.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EasyManager.Infra.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(EasyManagerContext context) : base(context)
        {
        }

        public Product GetByIdWithBundle(Guid id) => DbSet.Include(x => x.Bundles).ThenInclude(x => x.Product).FirstOrDefault(x => x.Id == id);
    }
}