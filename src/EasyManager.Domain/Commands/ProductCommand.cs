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
        public string Description { get; protected set; }
        public Guid Category { get; protected set; }
        public string InternalCode { get; protected set; }
        public string Barcode { get; protected set; }
        public ProductType ProductType { get; protected set; }
        public bool Active { get; protected set; }
        #endregion

        #region Stock
        public double Immobilized { get; protected set; }
        public double Consumption { get; protected set; }
        public double Resale { get; protected set; }
        public double ResaleMin { get; protected set; }
        public double ResaleMax { get; protected set; }
        #endregion

        #region Values ​​and cost
        public List<SalesTable> SalesTable { get; protected set; }
        public double OtherExpenses { get; protected set; }
        public double Cost { get; protected set; }

        #endregion

        #region Weight and dimentions
        public double Weight { get; protected set; }
        public double Height { get; protected set; }
        public double Width { get; protected set; }
        public double Length { get; protected set; }
        #endregion
    
        #region Details
        public bool SoldSeparately { get; protected set; }
        public double Comission { get; protected set; }
        public string Observations { get; protected set; }

        #endregion

        #region Attributes
        public List<Attribute> Attributes { get; protected set; }
        #endregion

        #region Bundle
        public List<ProductBundle<ProductCommand<T>>> Bundles { get; protected set; }
        #endregion

        #region Manufacture
        public Guid Manufacture { get; protected set; }
        #endregion
    }
}