using System;

namespace EasyManager.Domain.Events
{
    public class FinancialRemovedEvent : FinancialEvent
    {
        public FinancialRemovedEvent(Guid id) => Id = AggregateId = id;
    }
}