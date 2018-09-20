using System;
using EasyManager.Domain.Core.Commands;

namespace EasyManager.Domain.Commands
{
    public abstract class CategoryCommand<T> : Command<T>
    {
        public string Description { get; protected set; }
        public string Location { get; protected set; }   
        public Guid? ParentCategory { get; protected set; }  
    }
}