using System;
using EasyManager.Domain.Types;

namespace EasyManager.Application.ViewModels
{
    public class PurchaseShortViewModel
    {
        public int ReceiptNumber { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime DateEntry { get; set; }
    }
}