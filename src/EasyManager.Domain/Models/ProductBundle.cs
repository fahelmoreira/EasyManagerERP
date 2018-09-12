using EasyManager.Domain.Core.Model;

namespace EasyManager.Domain.Models
{
    public class ProductBundle : Entity
    {
        public Product Product { get; set; }
        public double Amount { get; set; }
    }
}