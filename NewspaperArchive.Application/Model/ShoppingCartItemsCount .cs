using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NewspaperArchive.Application.Model
{
    public class ShoppingCartItemsCount
    {
        [Key]
        public int ItemCount { get; set; }
        public int ShoppingCartId { get; set; }
    }
}
