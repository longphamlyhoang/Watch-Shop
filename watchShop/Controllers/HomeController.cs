using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using watchShop.Models;
using watchShop.Models.Cart;
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
        public const string CARTKEY = "WATCHSHOP";
        [Route("/Home/")]
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
        [Route("/Home/AddToCart/{proId:int}", Name = "Index")]
        public IActionResult AddToCart(int proId)
        {
            var pro = productService.Get(proId);
            if (pro == null)
            {
                return NotFound("No produts");
            }
            var proItem = new ProductItem()
            {
                
                 Pictures = pro.Pictures,
                 Price = pro.Price,
                  ProductId = pro.ProductId,
                  ProductName = pro.ProductName,
                  Quantity = pro.Quantity,
                  Status = pro.Status
            };
            var cart = GetCartItems();
            var cartitem = cart.Find(s => s.productItem.ProductId == proId);
            if (cartitem != null)
            {
                cartitem.Quantity++;
            }
            else
            {
                cart.Add(new CartItem() { Quantity = 1, productItem = proItem });
            }

            SaveCartSession(cart);
            return RedirectToAction("Cart");
        }
        List<CartItem> GetCartItems()
        {
            var session = HttpContext.Session;
            string jsoncart = session.GetString(CARTKEY);
            if (jsoncart != null)
            {
                return JsonConvert.DeserializeObject<List<CartItem>>(jsoncart);
            }
            return new List<CartItem>();
        }
        void SaveCartSession(List<CartItem> ls)
        {
            var session = HttpContext.Session;
            string jsoncart = JsonConvert.SerializeObject(ls);
            session.SetString(CARTKEY, jsoncart);
        }
        void ClearCart()
        {
            var session = HttpContext.Session;
            session.Remove(CARTKEY);
        }
        [Route("Home/Cart")]
        public IActionResult Cart()
        {
            return View(GetCartItems());
        }
        [Route("Home/UpdateCart", Name = "updatecart")]
        [HttpPost]
        public IActionResult UpdateCart([FromForm] int proId, [FromForm] int quantity)
        {
            var cart = GetCartItems();
            var cartitem = cart.Find(s => s.productItem.ProductId == proId);
            if (cartitem != null)
            {
                cartitem.Quantity = quantity;
            }
            SaveCartSession(cart);
            return Ok();
        }
        [Route("/Home/RemoveCart/{proId:int}")]
        public IActionResult RemoveCart([FromRoute] int proId)
        {
            var cart = GetCartItems();
            var cartitem = cart.Find(p => p.productItem.ProductId == proId);
            if (cartitem != null)
            {
                cart.Remove(cartitem);
            }
            SaveCartSession(cart);
            return RedirectToAction(nameof(Cart));
        }
    }
}
