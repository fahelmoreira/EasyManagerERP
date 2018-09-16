using System;
using System.Collections.Generic;
using EasyManager.Domain.Models;
using EasyManager.Domain.Types;

namespace EasyManager.Application.ViewModels
{
    public class PurchaseViewModel : BaseViewModel
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