using System;
using EasyManager.Domain.Core.Model;

namespace EasyManager.Domain.Models
{
    public class BankAccount : Entity
    {
        public BankAccount()
        {
        }

        public BankAccount(Guid? Bank)
        {
            if(Bank != null)
                this.Bank = new Bank{ Id = Bank.Value};
            else
                Bank = null;

        }
        public string Name { get; set; }
        public bool IsBankAccount { get; set; }
        public Bank Bank { get; set; }
        public int? Agency { get; set; }
        public int? Digit { get; set; }
        public int? AccountNumber { get; set; }
        public int? Wallet { get; set; }
        public string Observations { get; set; }
        public double InitialBalance { get; set; }
    }
}