using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using watchShop.Entities;
using watchShop.Models.Users;

namespace watchShop.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UsersController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var appUsers = await userManager.Users.ToListAsync();
            var users = new List<User>();
            foreach (var u in appUsers)
            {
                var user = new User()
                {
                    Avatar = u.Avatar,
                    Email = u.Email,
                    Phone = u.PhoneNumber,
                    UserId = u.Id,
                    UserName = u.UserName,
                    Roles = string.Join(',', Task.Run(async () => await userManager.GetRolesAsync(u)).Result.ToArray())
                };
                users.Add(user);
            }
            return View(users);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Roles = await roleManager.Roles.ToListAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateUser model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    AppUser user = new AppUser()
                    {
                        UserName = model.UserName,
                        Email = model.Email,
                        NormalizedEmail = model.Email.ToLower(),
                        NormalizedUserName = model.UserName.ToLower(),
                        LockoutEnabled = false,
                        Avatar = "~/Images/avatar.png"
                    };

                    PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();
                    user.PasswordHash = passwordHasher.HashPassword(user, "Asdf1234!");
                    var createUserResult = await userManager.CreateAsync(user);
                    if (createUserResult.Succeeded)
                    {
                        var userRolesResult = await userManager.AddToRoleAsync(user, model.RoleName);
                        if (userRolesResult.Succeeded)
                        {
                            return RedirectToAction("Index");
                        }
                    }

                }
                catch (Exception ex)
                {
                    ViewBag.Roles = await roleManager.Roles.ToListAsync();
                    return View();
                }

            }
            ViewBag.Roles = await roleManager.Roles.ToListAsync();
            return View();
        }
    }
}
