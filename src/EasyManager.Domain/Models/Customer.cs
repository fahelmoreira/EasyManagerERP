using System;
using System.Collections.Generic;
using EasyManager.Domain.Core.Model;
using EasyManager.Domain.Types;

namespace EasyManager.Domain.Models
{
    public class Customer : Entity
    {
        /// <summary>
        /// Customer trade name
        /// </summary>
        public string TradeName { get; set; }
        /// <summary>
        /// Type of customer
        /// </summary>
        public ClientType Type { get; set; }
        /// <summary>
        /// Individual taxpayer's number
        /// </summary>
        public string IndividualTaxpayerId { get; set; }
        /// <summary>
        /// Corporate taxpayer's number
        /// </summary>
        public string CorporateTaxpayerId { get; set; }
        /// <summary>
        /// Customer's address
        /// </summary>
        /// <value></value>
        public string Address { get; set; }
        /// <summary>
        /// Customer's Contact
        /// </summary>
        /// <value></value>
        public string Contacts { get; set; }
    }
}