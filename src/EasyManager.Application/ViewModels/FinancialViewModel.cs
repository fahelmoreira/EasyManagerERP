using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EasyManager.Domain.Models;
using EasyManager.Domain.Types;

namespace EasyManager.Application.ViewModels
{
    public class FinancialViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "The description is required")]
        public string Description { get; set; }
        public BudgetType? BudgetType { get; set; }
        public Guid PaymentMethod { get; set; }
        public DateTime DueDate { get; set; }
        public double Values { get; set; }
        public List<Installment> InstallmentInformation { get; set; }
        public bool Confirm { get; set; }
    }
}