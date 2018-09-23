using System;
using System.Collections.Generic;
using EasyManager.Domain.Core.Model;
using EasyManager.Domain.Types;
using Newtonsoft.Json;

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
        public Financial(Guid paymentMethod, List<Installment> installmentInformation)
        {
            PaymentMethod = new PaymentMethod {Id = paymentMethod};
            InstallmentInformation = JsonConvert.SerializeObject(installmentInformation);
            Confirm = false;
        }
    }
}