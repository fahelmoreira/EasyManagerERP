using System;
using System.Collections.Generic;
using EasyManager.Domain.Core.Commands;
using EasyManager.Domain.Models;
using EasyManager.Domain.Types;

namespace EasyManager.Domain.Commands
{
    public abstract class FinancialCommand<T> : Command<T>
    {
        public BudgetType? BudgetType { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string description { get; set; }
        public DateTime DueDate { get; set; }
        public double Values { get; set; }
        public List<Installment> InstallmentInformation { get; set; }
        public bool Confirm { get; set; }
    }
}