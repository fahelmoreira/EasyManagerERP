using EasyManager.Domain.Core.Model;

namespace EasyManager.Domain.Models
{
    public class ProductPurchase : Entity
    {
        public string Description { get; set; }
        public string Details { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
    }
}