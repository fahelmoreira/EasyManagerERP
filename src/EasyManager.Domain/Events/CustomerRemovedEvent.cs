using System;
using EasyManager.Domain.Core.Events;

namespace EasyManager.Domain.Events
{
    public class CustomerRemovedEvent : Event
    {
        public Guid Id { get; set; }
        public CustomerRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

    }
}