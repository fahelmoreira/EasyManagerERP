using System;
using System.Collections.Generic;
using EasyManager.Domain.Core.Model;
using EasyManager.Domain.Types;

namespace EasyManager.Domain.Models
{
    public class Customer : Entity
    {
        #region Personal data
            
        /// <summary>
        /// Customer's trade name
        /// </summary>
        public string TradeName { get; set; }
        /// <summary>
        /// Customer's corporate name
        /// </summary>
        /// <value></value>
        public string CorporateName { get; set; }
        /// <summary>
        /// Customer's name
        /// </summary>
        /// <value></value>
        public string Name { get; set; }
        /// <summary>
        /// Customer's code
        /// </summary>
        /// <value></value>
        public string Code { get; set; }
        /// <summary>
        /// Customer's email
        /// </summary>
        /// <value></value>
        public string Email { get; set; }
        /// <summary>
        /// Customer's phone number
        /// </summary>
        /// <value></value>
        public string PhoneNumber { get; set; }
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
        public bool Active { get; set; }

        #endregion

        #region Secondary data

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Customer's gender
        /// </summary>
        /// <value></value>
        public GenderType Gender { get; set; }
        /// <summary>
        /// Customer's Profession
        /// </summary>
        /// <value></value>
        public string Profession { get; set; }
        /// <summary>
        /// Customer father's name
        /// </summary>
        /// <value></value>
        public string FatherName { get; set; }
        /// <summary>
        /// Customer mother's name
        /// </summary>
        /// <value></value>
        public string MotherName { get; set; }
        /// <summary>
        /// Customer's marital status
        /// </summary>
        /// <value></value>
        public MaritalStatus MaritalStatus { get; set; }
        
        public bool ReceiveEmail { get; set; }
        public double CreditLimit { get; set; }

        #endregion

        public Customer()
        {
            Active = true;
            ReceiveEmail = true;
        }
    }
}