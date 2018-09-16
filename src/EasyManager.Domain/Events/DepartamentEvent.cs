using System;
using EasyManager.Domain.Core.Events;

namespace EasyManager.Domain.Events
{
    public abstract class DepartamentEvent : Event
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}