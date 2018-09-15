using System;
using EasyManager.Domain.Core.Events;
using EasyManager.Domain.Types;

namespace EasyManager.Domain.Events
{
    public abstract class PaymentMethodEvent : Event
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid PaymentType { get; set; }
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