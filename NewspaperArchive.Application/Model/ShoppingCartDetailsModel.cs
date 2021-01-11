using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace NewspaperArchive.Application.Model
{
       public class ShoppingCartDetailsModel
    {

        public string ImageId { get; set; }
        public string Item { get; set; }
        public string Description { get; set; }
        public string UnitPrice { get; set; }
        public bool IsChecked { get; set; }

        [Required]
        public IList<SelectListItem> ShippingPackages { get; set; }

        [Required]
        public List<SelectListItem> Colors { get; set; }

        //[Required]
        //public IEnumerable<SelectListItem> iShippingPackages { get; set; }

        [Required]
        [RegularExpression(@"[0-9]*$", ErrorMessage = "Please enter a non-zero number to change quantity.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Select a Shipping Package.")]
        public string ShippingPackageId { get; set; }

        [Required(ErrorMessage = "Select a Color.")]
        public string ColorId { get; set; }
        public string ItemTypeName { get; set; }

        public Int32 ShoppingCartItemsId { get; set; }
        public Int32 ItemTypeId { get; set; }
        public string ItemValue { get; set; }

    }
}
