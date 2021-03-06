using System;
using System.Collections.Generic;
using EasyManager.Domain.Core.Events;
using EasyManager.Domain.Models;
using EasyManager.Domain.Types;

namespace EasyManager.Domain.Events
{
    public abstract class OrderEvent : Event
    {
        public Guid Id { get; set; }
        public int OrderNumber { get; set; }
        public OrderStatus Status { get; set; }
        public Departament Departament { get; set; }
        public Customer Customer { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public DateTime? DeliveryTime { get; set; }
        public List<ProductOrder> ProductOrder { get; set; }
        public string Observations { get; set; }
        public double DiscountValue { get; set; }
        public double DiscountPercentage { get; set; }
        public double DeliveryFee { get; set; }
        public string PaymentMethod { get; set; }
    }
}