using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace watchShop.Models.Cart
{
    public class CartItem
    {
        public int Quantity { get; set; }
        public ProductItem productItem { get; set; }
    }
}
