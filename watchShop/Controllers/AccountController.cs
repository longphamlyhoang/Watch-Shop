using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using watchShop.Entities;
using watchShop.Models.Accout;

namespace watchShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;

        private readonly SignInManager<AppUser> signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Login(string ReturUrl)
        {
            ViewBag.ReturnUrl = ReturUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Login model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var signResult = await signInManager.PasswordSignInAsync(user, model.Password, model.RemenberMe, false);
                    if (signResult.Succeeded)
                    {
                        if (string.IsNullOrEmpty(model.ReturnUrl))
                            return RedirectToAction("Index", "Category");
                        return LocalRedirect(model.ReturnUrl);
                    }
                    ModelState.AddModelError("", "Invalid user or password");
                }
            }
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
