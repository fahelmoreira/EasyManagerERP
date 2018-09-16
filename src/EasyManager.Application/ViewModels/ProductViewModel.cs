using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EasyManager.Domain.Models;
using EasyManager.Domain.Types;

namespace EasyManager.Application.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        public ProductViewModel()
        {
            Active = true;
        }

        #region Informations
        [Required(ErrorMessage = "The description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The category is required")]
        public Guid Category { get; set; }
        [Required(ErrorMessage = "The internal code is required")]        
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
        public List<SalesTable> SalesTable { get; set; }
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
        public List<Attribute> Attributes { get; set; }
        #endregion

        #region Bundle
        public List<ProductBundle<ProductViewModel>> Bundles { get; set; }
        #endregion

        #region Manufacture
        [Required(ErrorMessage = "The manufacture is required")]
        public Guid Manufacture { get; set; }
        #endregion
    }
}