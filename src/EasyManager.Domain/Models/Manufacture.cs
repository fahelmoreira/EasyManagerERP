using EasyManager.Domain.Core.Model;

namespace EasyManager.Domain.Models
{
    public class Manufacture : Entity
    {
        /// <summary>
        /// Manufacture trade name
        /// </summary>
        public string TradeName { get; set; }
        /// <summary>
        /// Manufacture's corporate name
        /// </summary>
        /// <value></value>
        public string CorporateName { get; set; }
        /// <summary>
        /// Manufacture's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Corporate taxpayer's number
        /// </summary>
        public string CorporateTaxpayerId { get; set; }
        /// <summary>
        /// Manufacture individual taxpayer number
        /// </summary>
        /// <value></value>
        public string IndividualTaxpayerId { get; set; }
        /// <summary>
        /// Manufacture address
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Manufacture contacts
        /// </summary>
        public string Contacts { get; set; }
        /// <summary>
        /// Manufacture main email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Manufacture main phone number
        /// </summary>
        public string PhoneNumber { get; set; }
        public bool Active { get; set; }

        public Manufacture()
        {
            Active = true;
        }
    }
}