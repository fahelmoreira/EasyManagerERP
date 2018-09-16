using System;
using EasyManager.Domain.Types;

namespace EasyManager.Application.ViewModels
{
    public class OrderShortViewModel
    {
        public int OrderNumber { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime? DeliveryDate { get; set; }
    }
}