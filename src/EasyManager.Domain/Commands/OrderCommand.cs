using System;
using System.Collections.Generic;
using EasyManager.Domain.Core.Commands;
using EasyManager.Domain.Models;
using EasyManager.Domain.Types;

namespace EasyManager.Domain.Commands
{
    public abstract class OrderCommand<T> : Command<T>
    {
        public int OrderNumber { get; set; }
        public OrderStatus Status { get; set; }
        public Guid Departament { get; set; }
        public Guid Customer { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public DateTime? DeliveryTime { get; set; }
        public List<ProductOrder> ProductOrder { get; set; }
        public string Observations { get; set; }
        public double DiscountValue { get; set; }
        public double DiscountPercentage { get; set; }
        public double DeliveryFee { get; set; }
        public PurchasePaymentInformation PaymentMethod { get; set; }
    }
}