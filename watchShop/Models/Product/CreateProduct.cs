using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace watchShop.Models.Product
{
    public class CreateProduct
    {
        [Required]
        [StringLength(200)]
        public string ProductName { get; set; }
        [Required]
        public string TradeMark { get; set; }
        [Required]
        public int Price { get; set; }
        public bool Status { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public IFormFile Pictures { get; set; }
        public int CategoryId { get; set; }

    }
}
