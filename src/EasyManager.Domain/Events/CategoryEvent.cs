using System;
using EasyManager.Domain.Core.Events;

namespace EasyManager.Domain.Events
{
    public abstract class CategoryEvent : Event
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }   
        public Guid ParentCategory { get; set; }  
    }
}