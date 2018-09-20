using System;
using System.Collections.Generic;
using EasyManager.Domain.Core.Commands;
using EasyManager.Domain.Models;
using EasyManager.Domain.Types;

namespace EasyManager.Domain.Commands
{
    public abstract class PurchaseCommand<T> : Command<T>
    {
        public int ReceiptNumber { get; protected set; }
        public int Serie { get; protected set; }
        public OrderStatus Status { get; protected set; }
        public Guid Manufacture { get; protected set; }
        public DateTime DocumentData { get; protected set; }
        public DateTime DateEntry { get; protected set; }
        public List<ProductOrder> Products { get; protected set; }
        public PurchasePaymentInformation PaymentMethod { get; protected set; }
        public string Observations { get; protected set; }
    }
}