using System;
using EasyManager.Domain.Core.Model;

namespace EasyManager.Domain.Models
{
    public class Contact : Entity
    {
        /// <summary>
        /// Fistname of the contact
        /// </summary>
        /// <value></value>
        public string FistName { get; set; }
        /// <summary>
        /// Lastname of the contact
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Fullname of the contact
        /// </summary>
        public string FullName => $"{FistName} {LastName}";
        /// <summary>
        /// The contact phone number
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Email of the contact
        /// </summary>
        /// <value></value>
        public string email { get; set; }
    }
}