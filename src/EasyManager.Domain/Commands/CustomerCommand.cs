using System;
using System.Collections.Generic;
using EasyManager.Domain.Core.Commands;
using EasyManager.Domain.Models;
using EasyManager.Domain.Types;

namespace EasyManager.Domain.Commands
{
    /// <summary>
    /// Defaults customer command parameters
    /// </summary>
    public abstract class CustomerCommand<T> : Command<T>
    {
        public string TradeName { get; protected set; }
        public string CorporateName { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public ClientType Type { get; protected set; }
        public string IndividualTaxpayerId { get; protected set; }
        public string CorporateTaxpayerId { get; protected set; }
        public Address Address { get; protected set; }
        public List<Contact> Contacts { get; protected set; }
        public DateTime BirthDate { get; protected set; }
        public GenderType Gender { get; protected set; }
        public string Profession { get; protected set; }
        public string FatherName { get; protected set; }
        public string MotherName { get; protected set; }
        public MaritalStatus MaritalStatus { get; protected set; }
        public bool ReceiveEmail { get; protected set; }
        public double CreditLimit { get; protected set; }
        public bool Active { get; protected set; }
    }
}