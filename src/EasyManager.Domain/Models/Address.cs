using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyManager.Domain.Models
{
    /// <summary>
    /// Model for the address information
    /// </summary>
    [Table("Addresses")]
    public class Address
    {
        public Guid Id{ get; private set; }
        /// <summary>
        /// The address
        /// </summary>
        public string AddressInfo { get; set; }
        /// <summary>
        /// The number of the address
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// The complement
        /// </summary>
        public string Complement { get; set; }
        /// <summary>
        /// The zip-Code
        /// </summary>
        public string ZipCode { get; set; }
        /// <summary>
        /// The city
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// The state
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// The constry
        /// </summary>
        public string Country { get; set; }

        public Address()
        {
            Id = new Guid();
        }
    }
}