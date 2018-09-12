using System;
using System.Collections.Generic;
using EasyManager.Domain.Core.Events;
using EasyManager.Domain.Models;

namespace EasyManager.Domain.Events
{
    public abstract class ManufactureEvent : Event
    {
        public Guid Id { get; set; }
        public string TradeName { get; set; }
        public string CorporateTaxpayerId { get; set; }
        public Address Address { get; set; }
        public List<Contact> Contacts { get; set; }
    }
}