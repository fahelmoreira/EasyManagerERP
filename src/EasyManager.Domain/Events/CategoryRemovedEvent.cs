using System;
using EasyManager.Domain.Core.Events;

namespace EasyManager.Domain.Events
{
    public class CategoryRemovedEvent : Event
    {
        public CategoryRemovedEvent(Guid id) => id = AggregateId = id;
    }
}