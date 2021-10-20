using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using watchShop.Entities;
using watchShop.Models.Accout;
using watchShop.Services;

namespace watchShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;

        private readonly SignInManager<AppUser> signInManager;

        public AccountController(UserManager<AppUser> userManager,
                                SignInManager<AppUser> signInManager)
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
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(Register register)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser()
                {
                    Email = register.Email,
                    UserName = register.Email
                };
                var result = await userManager.CreateAsync(user, register.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                return View();
            }
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
