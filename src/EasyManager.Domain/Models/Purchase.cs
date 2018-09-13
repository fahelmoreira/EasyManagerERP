using System;
using EasyManager.Domain.Core.Model;
using EasyManager.Domain.Types;

namespace EasyManager.Domain.Models
{
    public class Purchase : Entity
    {
        public int ReceiptNumber { get; set; }
        public int Serie { get; set; }
        public OrderStatus Status { get; set; }
        public Manufacture Manufacture { get; set; }
        public DateTime DocumentData { get; set; }
        public DateTime DateEntry { get; set; }
        public string Products { get; set; }
        public string PaymentMethod { get; set; }
        public string Observations { get; set; }
    }
}