using System;
using System.Collections.Generic;
using EasyManager.Domain.Core.Commands;
using EasyManager.Domain.Models;
using EasyManager.Domain.Types;

namespace EasyManager.Domain.Commands
{
    public abstract class PurchaseCommand<T> : Command<T>
    {
        public int ReceiptNumber { get; set; }
        public int Serie { get; set; }
        public OrderStatus Status { get; set; }
        public Guid Manufacture { get; set; }
        public DateTime DocumentData { get; set; }
        public DateTime DateEntry { get; set; }
        public List<ProductOrder> Products { get; set; }
        public PurchasePaymentInformation PaymentMethod { get; set; }
        public string Observations { get; set; }
    }
}