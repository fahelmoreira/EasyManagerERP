using System;
using EasyManager.Domain.Core.Model;
using EasyManager.Domain.Types;

namespace EasyManager.Domain.Models
{
    public class PaymentMethod : Entity
    {
        /// <summary>
        /// Payment description
        /// </summary>
        /// <value></value>
        public string Description { get; set; }
        /// <summary>
        /// Type of payment
        /// </summary>
        /// <value></value>
        public PaymentType PaymentType { get; set; }
        public bool Active { get; set; }
        /// <summary>
        /// Bank account informations
        /// </summary>
        /// <value></value>
        public BankAccount BankAccount { get; set; }
        /// <summary>
        /// send to financial
        /// </summary>
        /// <value></value>
        public bool SendToFinatial { get; set; }
        /// <summary>
        /// Configure if should automatic confirmate
        /// </summary>
        public ConfirmationType ConfirmationType { get; set; }

        public double StoreInterest { get; set; }
        public double FinanceInterest { get; set; }
        public double Fine { get; set; }
        public double DelayFine { get; set; }
        public double DelayFinePercentage { get; set; }
        /// <summary>
        /// Fee charged by the company to the bank
        /// </summary>
        /// <value></value>
        public double BankFee { get; set; }

        /// <summary>
        /// CredcardOperator
        /// </summary>
        /// <value></value>
        public CredcardOperator CredcardOperator { get; set; }
        /// <summary>
        /// Cred card operation fee
        /// </summary>
        /// <value></value>
        public double OperationFee { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public int InstallmentsMax { get; set; }
        /// <summary>
        /// Interval of days between installments posted on this form of payment
        /// </summary>
        /// <value></value>
        public int InstallmentsInterval { get; set; }
        /// <summary>
        /// Indicates whether the range should be applied on the first
        /// </summary>
        /// <value></value>
        public bool? StartOnFirst { get; set; }

        public PaymentMethod()
        {
            ConfirmationType = ConfirmationType.Never;
            PaymentType = PaymentType.PayAndReceive;
            Active = true;
        }

        public PaymentMethod(Guid credcardOperator, Guid bankAccount)
        {
            CredcardOperator = new CredcardOperator { Id = credcardOperator };
            BankAccount = new BankAccount {Id = bankAccount};
            ConfirmationType = ConfirmationType.Never;
            PaymentType = PaymentType.PayAndReceive;
            Active = true;
        }
    }

}