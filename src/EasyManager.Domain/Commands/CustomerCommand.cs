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
    public abstract class CustomerCommand : Command
    {
        public Guid Id { get; protected set; }
        public string TradeName { get; protected set; }
        public ClientType Type { get; protected set; }
        public string IndividualTaxpayerId { get; protected set; }
        public string CorporateTaxpayerId { get; protected set; }
        public Address Address { get; protected set; }
        public List<Contact> Contacts { get; protected set; }
    }
}