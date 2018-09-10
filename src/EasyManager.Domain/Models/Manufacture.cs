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
        /// Corporate taxpayer's number
        /// </summary>
        public string CorporateTaxpayerId { get; set; }
        /// <summary>
        /// Manufacture address
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Manufacture contacts
        /// </summary>
        public string Contacts { get; set; }
    }
}