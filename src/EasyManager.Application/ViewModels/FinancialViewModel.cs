using System;
using System.Collections.Generic;
using EasyManager.Domain.Models;
using EasyManager.Domain.Types;

namespace EasyManager.Application.ViewModels
{
    public class FinancialViewModel : BaseViewModel
    {
        public BudgetType? BudgetType { get; set; }
        public Guid PaymentMethod { get; set; }
        public string description { get; set; }
        public DateTime DueDate { get; set; }
        public double Values { get; set; }
        public List<Installment> InstallmentInformation { get; set; }
        public bool Confirm { get; set; }
    }
}