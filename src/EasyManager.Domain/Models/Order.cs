using System;
using System.Collections.Generic;
using EasyManager.Domain.Core.Model;
using EasyManager.Domain.Types;
using Newtonsoft.Json;

namespace EasyManager.Domain.Models
{
    public class Order : Entity
    {
        public int OrderNumber { get; set; }
        public OrderStatus Status { get; set; }
        public Departament Departament { get; set; }
        public Customer Customer { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public DateTime? DeliveryTime { get; set; }
        public string ProductOrder { get; set; }
        public string Observations { get; set; }
        public double DiscountValue { get; set; }
        public double DiscountPercentage { get; set; }
        public double DeliveryFee { get; set; }
        public string PaymentMethod { get; set; }

        public Order()
        {
        }
        public Order(Guid departament, Guid customer, string paymentMethod, List<ProductOrder> productOrder )
        {
            Departament = new Departament{Id = departament};
            Customer = new Customer{Id = customer};
            PaymentMethod = paymentMethod;
            ProductOrder = JsonConvert.SerializeObject(productOrder);
        }
    }
}