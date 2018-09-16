using System;
using System.Collections.Generic;
using EasyManager.Domain.Core.Events;
using EasyManager.Domain.Models;
using EasyManager.Domain.Types;

namespace EasyManager.Domain.Events
{
    public abstract class CustomerEvent : Event
    {
        public Guid Id { get; protected set; }
        public string TradeName { get; protected set; }
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