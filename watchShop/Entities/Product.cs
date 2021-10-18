using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace watchShop.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
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
        public string Pictures { get; set; }
        [ForeignKey("Categories")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
