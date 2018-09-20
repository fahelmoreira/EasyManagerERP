using System;
using System.ComponentModel.DataAnnotations;

namespace EasyManager.Application.ViewModels
{
    public class BankAccountViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "The name is required")]
        public string Name { get; set; }
        public bool IsBankAccount { get; set; }
        public Guid? Bank { get; set; }
        public int? Agency { get; set; }
        public int? Digit { get; set; }
        public int? AccountNumber { get; set; }
        public int? Wallet { get; set; }
        public string Observations { get; set; }
        public double InitialBalance { get; set; }
    }
}