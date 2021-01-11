using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NewspaperArchive.Application.Model
{
    public class ShoppingCartDetails
    {
        [Key]
        public int shoppingcartid { get; set; }
        public decimal totalcost { get; set; }
        public int ShoppingCartitemsId { get; set; }
        public int quantity { get; set; }
        public decimal itemcost { get; set; }
        public decimal containercost { get; set; }
        public string colorname { get; set; }
        public int colorid { get; set; }
        public string containername { get; set; }
        public int containertypeid { get; set; }
        public int userid { get; set; }
        public string itemtypename { get; set; }
        public int itemtypeid { get; set; }
        public string shoppingcartimage { get; set; }
        public string websitetitle { get; set; }
        public string countryName { get; set; }
        public string stateName { get; set; }
        public string cityName { get; set; }
        public string pubTitle { get; set; }
        public string pubDate { get; set; }
        public int pubid { get; set; }
        public int countryid { get; set; }
        public int stateid { get; set; }
        public int cityid { get; set; }
        public string destimagepath { get; set; }
        public int imageid { get; set; }
        public int itemvalue { get; set; }
        public int pagenum { get; set; }
        public string displayname { get; set; }
        public decimal initialcost { get; set; }
        public string plantype { get; set; }
        public int planid { get; set; }
        public int roleid { get; set; }
        public int initialPlanLength { get; set; }
    }

}

