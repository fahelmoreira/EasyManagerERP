using System.Collections.Generic;
using EasyManager.Domain.Core.Model;
using EasyManager.Domain.Types;

namespace EasyManager.Domain.Models
{
    public class Product : Entity
    {
        #region Informations

        /// <summary>
        /// Product's description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Product's category
        /// </summary>
        public Category Category { get; set; }
        /// <summary>
        /// Product's internal code
        /// </summary>
        public string InternalCode { get; set; }
        /// <summary>
        /// Product's bar code
        /// </summary>
        public string Barcode { get; set; }
        /// <summary>
        /// Product's type
        /// </summary>
        public ProductType ProductType { get; set; }
        /// <summary>
        /// Gets if the product is active
        /// </summary>
        public bool Active { get; set; }
        
        #endregion

        #region Stock
        
        /// <summary>
        /// Quantity in stock of durable goods
        /// For internal usage
        /// </summary>
        public double Immobilized { get; set; }
        /// <summary>
        /// Quantity in stock of non-durable goods
        /// For internal usage
        /// </summary>
        public double Consumption { get; set; }
        /// <summary>
        /// Quantity for resale
        /// </summary>
        public double Resale { get; set; }
        /// <summary>
        /// Minimum quantity for resale
        /// </summary>
        public double ResaleMin { get; set; }
        /// <summary>
        /// Maximum quantity for resale
        /// </summary>
        public double ResaleMax { get; set; }

        #endregion

        #region Values ​​and cost

        /// <summary>
        /// Product's sale table
        /// </summary>
        public string SalesTable { get; set; }
        public double OtherExpenses { get; set; }
        /// <summary>
        /// Product's cost value
        /// </summary>
        public double Cost { get; set; }

        #endregion

        #region Weight and dimentions

        /// <summary>
        /// Product's weight
        /// </summary>
        /// <value></value>
        public double Weight { get; set; }
        /// <summary>
        /// Product's height
        /// </summary>
        /// <value></value>
        public double Height { get; set; }
        /// <summary>
        /// Product's width
        /// </summary>
        /// <value></value>
        public double Width { get; set; }
        /// <summary>
        /// Product's Length
        /// </summary>
        /// <value></value>
        public double Length { get; set; }

        #endregion
    
        #region Details

        /// <summary>
        /// Indicates if the product can be sold separately
        /// </summary>
        /// <value></value>
        public bool SoldSeparately { get; set; }
        /// <summary>
        /// Product's comission
        /// </summary>
        /// <value></value>
        public double Comission { get; set; }
        /// <summary>
        /// Product's observations
        /// </summary>
        /// <value></value>
        public string Observations { get; set; }

        #endregion

        #region Attributes

        /// <summary>
        /// Product's attributes
        /// </summary>
        public string Attributes { get; set; }

        #endregion

        #region Bundle
        
        public IEnumerable<ProductBundle> Bundles { get; set; }

        #endregion

        #region Manufacture

        public Manufacture Manufacture { get; set; }
        #endregion

        public Product()
        {
            SoldSeparately = true;
            Active = true;
            Bundles = new List<ProductBundle>();
        }
    }
}