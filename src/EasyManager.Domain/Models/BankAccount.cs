using EasyManager.Domain.Core.Model;

namespace EasyManager.Domain.Models
{
    public class BankAccount : Entity
    {
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