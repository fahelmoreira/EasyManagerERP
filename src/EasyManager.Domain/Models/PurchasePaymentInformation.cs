using System;
using System.Collections.Generic;
using EasyManager.Domain.Core.Model;

namespace EasyManager.Domain.Models
{
    public class PurchasePaymentInformation : Entity
    {
       public double Value { get; set; }
       public int Installment  { get; set; }
       public double Interest { get; set; }
       public double InstallmentFee { get; set; }
       public int InstallmentInterval { get; set; }
       public DateTime FirstInstallment { get; set; }
       public List<Installment> Installments { get; set; }
    }
}