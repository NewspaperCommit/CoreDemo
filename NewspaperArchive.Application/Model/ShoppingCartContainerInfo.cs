using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NewspaperArchive.Application.Model
{
    public class ShoppingCartContainerInfo
        
    {
        [Key]
        public int ShoppingCartId { get; set; }
        public int ItemCount { get; set; }
        public List<ShoppingCartDetails> ShoppingCartInfo { get; set; }
        public List<ContainerType> ContainerTypeInfo { get; set; }
    }
}
