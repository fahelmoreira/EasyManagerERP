using System;
using EasyManager.Domain.Core.Events;

namespace EasyManager.Domain.Events
{
    public class ManufactureRemovedEvent : Event
    {
         public Guid Id { get; set; }

        public ManufactureRemovedEvent(Guid id) => Id = AggregateId = id;
    }
}