using System;
using System.Collections.Generic;
using EasyManager.Domain.Core.Events;
using EasyManager.Domain.Models;
using EasyManager.Domain.Types;

namespace EasyManager.Domain.Events
{
    public abstract class FinancialEvent : Event
    {
        public Guid Id { get; set; }
        public BudgetType? BudgetType { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string description { get; set; }
        public DateTime DueDate { get; set; }
        public double Values { get; set; }
        public List<Installment> InstallmentInformation { get; set; }
        public bool Confirm { get; set; }
    }
}