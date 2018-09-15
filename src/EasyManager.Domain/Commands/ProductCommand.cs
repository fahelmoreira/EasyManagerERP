using System;
using System.Collections.Generic;
using EasyManager.Domain.Core.Commands;
using EasyManager.Domain.Models;
using EasyManager.Domain.Types;

namespace EasyManager.Domain.Commands
{
    public abstract class ProductCommand<T> : Command<T>
    {
        #region Informations
        public string Description { get; set; }
        public Guid Category { get; set; }
        public string InternalCode { get; set; }
        public string Barcode { get; set; }
        public ProductType ProductType { get; set; }
        public bool Active { get; set; }
        #endregion

        #region Stock
        public double Immobilized { get; set; }
        public double Consumption { get; set; }
        public double Resale { get; set; }
        public double ResaleMin { get; set; }
        public double ResaleMax { get; set; }
        #endregion

        #region Values ​​and cost
        public string SalesTable { get; set; }
        public double OtherExpenses { get; set; }
        public double Cost { get; set; }

        #endregion

        #region Weight and dimentions
        public double Weight { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
        #endregion
    
        #region Details
        public bool SoldSeparately { get; set; }
        public double Comission { get; set; }
        public string Observations { get; set; }

        #endregion

        #region Attributes
        public string Attributes { get; set; }
        #endregion

        #region Bundle
        public List<ProductBundle<ProductCommand<T>>> Bundles { get; set; }
        #endregion

        #region Manufacture
        public Guid Manufacture { get; set; }
        #endregion
    }
}