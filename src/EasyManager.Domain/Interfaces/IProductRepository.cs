using System;
using EasyManager.Domain.Models;

namespace EasyManager.Domain.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
         Product GetByIdWithBundle(Guid id);
    }
}