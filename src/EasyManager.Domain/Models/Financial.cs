using System;
using EasyManager.Domain.Core.Model;
using EasyManager.Domain.Types;

namespace EasyManager.Domain.Models
{
    public class Financial : Entity
    {
        public BudgetType? BudgetType { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string description { get; set; }
        public DateTime DueDate { get; set; }
        public double Values { get; set; }
        public string InstallmentInformation { get; set; }
        public bool Confirm { get; set; }

        public Financial()
        {
            Confirm = false;
        }
        public Financial(Guid paymentMethod)
        {
            PaymentMethod = new PaymentMethod {Id = paymentMethod};
            Confirm = false;
        }
    }
}