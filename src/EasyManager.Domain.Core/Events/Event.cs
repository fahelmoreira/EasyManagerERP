using System;
using MediatR;

namespace EasyManager.Domain.Core.Events
{
    public abstract class Event : Message<Unit>, INotification
    {
        public DateTime Timestamp { get; private set; }

        protected Event()
        {
            Timestamp = DateTime.UtcNow;
        }
    }
}