using System;
using EasyManager.Domain.Types;

namespace EasyManager.Application.ViewModels
{
    public class PaymentMethodViewModel : BaseViewModel
    {
        public string Description { get; set; }
        public PaymentType PaymentType { get; set; }
        public bool Active { get; set; }
        public Guid BankAccount { get; set; }
        public bool SendToFinatial { get; set; }
        public ConfirmationType ConfirmationType { get; set; }
        public double StoreInterest { get; set; }
        public double FinanceInterest { get; set; }
        public double Fine { get; set; }
        public double DelayFine { get; set; }
        public double DelayFinePercentage { get; set; }
        public double BankFee { get; set; }
        public Guid CredcardOperator { get; set; }
        public double OperationFee { get; set; }
        public int InstallmentsMax { get; set; }
        public int InstallmentsInterval { get; set; }
        public bool? StartOnFirst { get; set; }
    }
}