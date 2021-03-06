using System;
using EasyManager.Domain.Core.Events;

namespace EasyManager.Domain.Events
{
    public class BankAccountRemovedEvent : Event
    {
        public Guid Id { get; set; }
        public BankAccountRemovedEvent(Guid id) => Id = AggregateId = id;

    }
}