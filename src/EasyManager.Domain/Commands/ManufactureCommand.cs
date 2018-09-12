using System;
using System.Collections.Generic;
using EasyManager.Domain.Core.Commands;
using EasyManager.Domain.Models;

namespace EasyManager.Domain.Commands
{
    public abstract class ManufactureCommand : Command
    {
        public Guid Id { get; set; }
        public string TradeName { get; set; }
        public string CorporateTaxpayerId { get; set; }
        public Address Address { get; set; }
        public List<Contact> Contacts { get; set; }

    }
}