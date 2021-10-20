using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace watchShop.Models.Cart
{
    public class ProductItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string TradeMark { get; set; }
        public int Price { get; set; }
        public bool Status { get; set; }
        public int Quantity { get; set; }
        public string Pictures { get; set; }
        public int CategoryId { get; set; }
    }
}
