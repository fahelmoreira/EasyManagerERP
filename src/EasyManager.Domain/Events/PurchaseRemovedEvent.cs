using System;

namespace EasyManager.Domain.Events
{
    public class PurchaseRemovedEvent : PurchaseEvent
    {
        public PurchaseRemovedEvent(Guid id) => Id = AggregateId = id;
    }
}