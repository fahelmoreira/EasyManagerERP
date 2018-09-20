using System;
using EasyManager.Domain.Core.Commands;
using EasyManager.Domain.Models;
using EasyManager.Domain.Types;

namespace EasyManager.Domain.Commands
{
    public abstract class PaymentMethodCommand<T> : Command<T>
    {
        public string Description { get; protected set; }
        public PaymentType PaymentType { get; protected set; }
        public bool Active { get; protected set; }
        public Guid BankAccount { get; protected set; }
        public bool SendToFinatial { get; protected set; }
        public ConfirmationType ConfirmationType { get; protected set; }
        public double StoreInterest { get; protected set; }
        public double FinanceInterest { get; protected set; }
        public double Fine { get; protected set; }
        public double DelayFine { get; protected set; }
        public double DelayFinePercentage { get; protected set; }
        public double BankFee { get; protected set; }
        public Guid CredcardOperator { get; protected set; }
        public double OperationFee { get; protected set; }
        public int InstallmentsMax { get; protected set; }
        public int InstallmentsInterval { get; protected set; }
        public bool? StartOnFirst { get; protected set; }
    }
}