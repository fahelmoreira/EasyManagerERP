using System;

namespace EasyManager.Domain.Events
{
    public class DepartamentRemovedEvent : DepartamentEvent
    {
        public DepartamentRemovedEvent(Guid id) => Id = AggregateId = id;
    }
}