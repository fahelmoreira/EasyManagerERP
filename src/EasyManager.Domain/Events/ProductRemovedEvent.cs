using System;

namespace EasyManager.Domain.Events
{
    public class ProductRemovedEvent : ProductEvent
    {
        public ProductRemovedEvent(Guid id) => Id = AggregateId = id;
    }
}