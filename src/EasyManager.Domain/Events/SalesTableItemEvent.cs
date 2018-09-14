using System;
using EasyManager.Domain.Core.Events;

namespace EasyManager.Domain.Events
{
    public class SalesTableItemEvent : Event
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Profit { get; set; }
        public double Price { get; set; }
    }
}