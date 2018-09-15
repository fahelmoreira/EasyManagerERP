using EasyManager.Domain.Core.Model;

namespace EasyManager.Domain.Models
{
    public class ProductBundle<T> : Entity
    {
        public T Product { get; set; }
        public double Amount { get; set; }
    }
}