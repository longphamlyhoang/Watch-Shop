using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using watchShop.Models.Category;
using watchShop.Services;

namespace watchShop.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }



        public IActionResult Index()
        {
            return View(categoryService.Gets());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Create create)
        {
            if (ModelState.IsValid)
            {
                if (categoryService.Create(create))
                {
                    return RedirectToAction("Index");
                }
            }
            return View(create);
        }




        [HttpGet]
        [Route("/Category/Edit/{catId}")]
        public IActionResult Edit(int catId)
        {
            var category = categoryService.Get(catId);
            var editView = new Edit()
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                Description = category.Description,
                Picture = category.Picture,
                Status = category.Status
            };
            return View(editView);
        }
        [HttpPost]
        public IActionResult Edit(Edit edit)
        {
            if (ModelState.IsValid)
            {
                if (categoryService.Edit(edit))
                {
                    return RedirectToAction("Index");
                }
            }
            return View(edit);
        }


        [HttpGet]
        [Route("/Category/ChangeStatus/{catId}")]
        public IActionResult ChangeStatus(int catId)
        {
            ViewBag.CategoryId = catId;
            if (categoryService.ChangStatus(catId))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
