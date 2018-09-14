using System;
using EasyManager.Domain.Core.Units;
using MediatR;

namespace EasyManager.Domain.Core.Events
{
    public class Message<T> : IRequest<T>
    {
        public string MessageType { get; protected set; }
        public Guid AggregateId { get; protected set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}