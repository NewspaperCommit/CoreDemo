using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NewspaperArchive.Application.Model
{
    public class ShoppingCartModel
    {

        public IList<ShoppingCartDetailsModel> CartDetails { get; set; }

        public decimal SubTotal { get; set; }
        public decimal ShippingTotal { get; set; }
        public decimal TotalCost { get; set; }
        public int CartCount { get; set; }
        public int ShoppingCartId { get; set; }
        public string RedirectForm { get; set; }
        public string GenerateScript { get; set; }

        public Nullable<int> Flag { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountedAmount { get; set; }
        public string DiscountDetails { get; set; }
        public ShoppingCartModel()
        {
            CartDetails = new List<ShoppingCartDetailsModel>();
            //GenerateScript = string.Empty;
        }
        //public class ShoppingCartItemsCount
        //{
        //    public int ItemCount { get; set; }
        //    public int ShoppingCartId { get; set; }
        //}
        //public class ResultDTO
        //{
        //    [Key]
        //    public int Id { get; set; }
        //}
    }       
}
