using System;
using EasyManager.Domain.Core.Commands;

namespace EasyManager.Domain.Commands
{
    public abstract class BankAccountCommand<T> : Command<T>
    {
        public string Name { get; protected set; }
        public bool IsBankAccount { get; protected set; }
        public Guid? Bank { get; protected set; }
        public int? Agency { get; protected set; }
        public int? Digit { get; protected set; }
        public int? AccountNumber { get; protected set; }
        public int Wallet { get; protected set; }
        public string Observations { get; protected set; }
        public double InitialBalance { get; protected set; }
    }
}