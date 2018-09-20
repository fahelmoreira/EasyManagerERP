using System;
using System.Collections.Generic;
using EasyManager.Domain.Core.Commands;
using EasyManager.Domain.Models;
using EasyManager.Domain.Types;

namespace EasyManager.Domain.Commands
{
    public abstract class FinancialCommand<T> : Command<T>
    {
        public BudgetType? BudgetType { get; protected set; }
        public Guid PaymentMethod { get; protected set; }
        public string description { get; protected set; }
        public DateTime DueDate { get; protected set; }
        public double Values { get; protected set; }
        public List<Installment> InstallmentInformation { get; protected set; }
        public bool Confirm { get; protected set; }
    }
}