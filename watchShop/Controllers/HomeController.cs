using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using watchShop.Models;
using watchShop.Models.Product;
using watchShop.Models.Shop;
using watchShop.Services;

namespace watchShop.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IProductService productService,
                             ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        public IActionResult Index()
        {
            return View(categoryService.Gets());
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet("/Home/Details/{productId}")]
        public IActionResult Details(int productId)
        {
            var pro = productService.Get(productId);
            var viewProduct = new ViewProduct()
            {
                CategoryId = pro.CategoryId,
                ProductName = pro.ProductName,
                PicturePath = pro.Pictures,
                Price = pro.Price,
                ProductId = pro.ProductId,
                Quantity = pro.Quantity,
                Status = pro.Status,
                TradeMark = pro.TradeMark
            };
            return View(viewProduct);
        }
    }
}
