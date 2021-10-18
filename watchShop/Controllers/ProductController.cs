using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using watchShop.Entities;
using watchShop.Models.Product;
using watchShop.Services;

namespace watchShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly IWebHostEnvironment webHostEnvironment;
        private static Category category = new Category();

        public ProductController(IProductService productService, ICategoryService categoryService, IWebHostEnvironment webHostEnvironment)
        {
            this.productService = productService;
            this.categoryService = categoryService;
            this.webHostEnvironment = webHostEnvironment;
        }
        [Route("/Product/Index/{catId}")]
        public IActionResult Index(int catId)
        {
            category = categoryService.Get(catId);
            ViewBag.Category = category;
            return View(productService.GetProductByCategoryId(catId));
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Category = category;
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateProduct model)
        {
            if (ModelState.IsValid)
            {
                model.CategoryId = category.CategoryId;
                var filename = "noavata.jpg";
                if (model.Pictures != null)
                {
                    var folderPath = Path.Combine(webHostEnvironment.WebRootPath, "Images");
                    filename = $"{Guid.NewGuid()}_{model.Pictures.FileName}";
                    var filePath = Path.Combine(folderPath, filename);
                    using (var fs = new FileStream(filePath, FileMode.Create))
                    {
                        model.Pictures.CopyTo(fs);
                    }
                }
                var product = new Product()
                {
                    CategoryId = model.CategoryId,
                    Pictures = $"~/Images/{filename}",
                    Price = model.Price,
                    ProductName = model.ProductName,
                    Quantity = model.Quantity,
                    Status = model.Status,
                    TradeMark = model.TradeMark
                };
                if (productService.Create(product))
                {
                    return RedirectToAction("Index", new { catId = category.CategoryId });
                }
            }
            ViewBag.Category = category;
            return View(model);
        }
        [HttpGet]
        [Route("Product/Edit/{productId}")]
        public IActionResult Edit(int productId)
        {
            var product = productService.Get(productId);
            var editProduct = new EditProduct()
            {
                CategoryId = product.CategoryId,
                ProductId = product.ProductId,
                ExistPicture = product.Pictures,
                Price = product.Price,
                ProductName = product.ProductName,
                Quantity = product.Quantity,
                Status = product.Status,
                TradeMark = product.TradeMark
            };
            ViewBag.Category = category;
            return View(editProduct);
        }
        [HttpPost]
        public IActionResult Edit(EditProduct model)
        {
            if (ModelState.IsValid)
            {
                var product = productService.Get(model.ProductId);
                product.CategoryId = model.CategoryId;
                product.Price = model.Price;
                product.ProductName = model.ProductName;
                product.Quantity = model.Quantity;
                product.ProductId = model.ProductId;
                product.Status = model.Status;
                product.TradeMark = model.TradeMark;
                if (model.Pictures != null)
                {
                    var existFilename = product.Pictures.Split("/").Last();
                    if (string.Compare(existFilename, "noavata.jpg") != 0)
                    {
                        System.IO.File.Delete(Path.Combine(webHostEnvironment.WebRootPath, "Images", existFilename));
                    }

                    var folderPath = Path.Combine(webHostEnvironment.WebRootPath, "Images");
                    var filename = $"{Guid.NewGuid()}_{model.Pictures.FileName}";
                    var filePath = Path.Combine(folderPath, filename);
                    using (var fs = new FileStream(filePath, FileMode.Create))
                    {
                        model.Pictures.CopyTo(fs);
                    }
                    product.Pictures = $"~/Images/{filename}";

                }
                if (productService.Edit(product))
                {
                    return RedirectToAction("Index", "Product", new { catId = model.CategoryId });
                }
            }
            ViewBag.Category = category;

            return View(model);
        }
        [HttpGet]
        [Route("Product/Detail/{productId}")]
        public IActionResult Detail(int productId)
        {
            var product = productService.Get(productId);
            var detailProduct = new DetailProduct()
            {
                CategoryId = product.CategoryId,
                ProductId = product.ProductId,
                PicturePath = product.Pictures,
                Price = product.Price,
                ProductName = product.ProductName,
                Quantity = product.Quantity,
                Status = product.Status,
                TradeMark = product.TradeMark
            };
            ViewBag.Category = category;
            return View(detailProduct);
        }

        [HttpGet]
        [Route("Product/Remove/{productId}")]
        public IActionResult Remove(int productId)
        {
            if (productService.Remove(productId))
            {
                return RedirectToAction("Index", "Product", new { catId = category.CategoryId });
            }
            return RedirectToAction("Index", "Detail", new { productId = productId });
        }
    }
}
