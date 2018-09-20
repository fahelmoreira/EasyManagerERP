using System;
using System.Collections.Generic;
using EasyManager.Domain.Core.Commands;
using EasyManager.Domain.Models;
using EasyManager.Domain.Types;

namespace EasyManager.Domain.Commands
{
    public abstract class OrderCommand<T> : Command<T>
    {
        public int OrderNumber { get; protected set; }
        public OrderStatus Status { get; protected set; }
        public Guid Departament { get; protected set; }
        public Guid Customer { get; protected set; }
        public DateTime? DeliveryDate { get; protected set; }
        public DateTime? DeliveryTime { get; protected set; }
        public List<ProductOrder> ProductOrder { get; protected set; }
        public string Observations { get; protected set; }
        public double DiscountValue { get; protected set; }
        public double DiscountPercentage { get; protected set; }
        public double DeliveryFee { get; protected set; }
        public PurchasePaymentInformation PaymentMethod { get; protected set; }
    }
}