using System;

namespace EasyManager.Domain.Events
{
    public class PaymentMethodRemovedEvent : PaymentMethodEvent
    {
        public PaymentMethodRemovedEvent(Guid id) => Id = AggregateId = id;
    }
}