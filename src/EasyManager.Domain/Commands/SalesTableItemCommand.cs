using System;
using EasyManager.Domain.Core.Commands;

namespace EasyManager.Domain.Commands
{
    public abstract class SalesTableItemCommand<T> : Command<T>
    {
        public string Name { get; set; }
        public double Profit { get; set; }
        public double Price { get; set; }
    }
}