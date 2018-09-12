using EasyManager.Domain.Core.Model;

namespace EasyManager.Domain.Models
{
    public class SalesTable : Entity
    {
        public string Name { get; set; }
        public double Profit { get; set; }
        public double Price { get; set; }
    }
}