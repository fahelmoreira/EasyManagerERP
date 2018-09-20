using System;
using EasyManager.Domain.Core.Commands;

namespace EasyManager.Domain.Commands
{
    public abstract class CategoryCommand<T> : Command<T>
    {
        public string Description { get; set; }
        public string Location { get; set; }   
        public Guid? ParentCategory { get; set; }  
    }
}