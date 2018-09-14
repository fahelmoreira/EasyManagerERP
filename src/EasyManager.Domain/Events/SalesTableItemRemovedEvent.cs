using System;
using EasyManager.Domain.Core.Events;

namespace EasyManager.Domain.Events
{
    public class SalesTableItemRemovedEvent : Event
    {
        public Guid Id { get; set; }
        public SalesTableItemRemovedEvent(Guid id) => Id = AggregateId = id;
    }
}