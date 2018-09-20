using System;
using EasyManager.Domain.Core.Events;

namespace EasyManager.Domain.Events
{
    public abstract class BankAccountEvent : Event
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsBankAccount { get; set; }
        public Guid? Bank { get; set; }
        public int? Agency { get; set; }
        public int? Digit { get; set; }
        public int? AccountNumber { get; set; }
        public int? Wallet { get; set; }
        public string Observations { get; set; }
    }
}