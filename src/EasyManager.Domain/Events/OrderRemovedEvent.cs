using System;

namespace EasyManager.Domain.Events
{
    public class OrderRemovedEvent : OrderEvent
    {
        public OrderRemovedEvent(Guid id) => Id = AggregateId = id;
    }
}