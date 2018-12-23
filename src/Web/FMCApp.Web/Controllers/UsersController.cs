using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FMCApp.Data.Models;
using FMCApp.Web.Models.ViewModels.InputModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace FMCApp.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<FMCAppUser> _userManager;
        private readonly SignInManager<FMCAppUser> _signInManager;

        public UsersController(UserManager<FMCAppUser> userManager, SignInManager<FMCAppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return this.View();
        }


        [HttpPost]
        public  async Task<IActionResult> Register(RegisterInputModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new FMCAppUser
                {
                    UserName = model.Username,
                    Email = model.Email,

                };
                var result = await _userManager.CreateAsync(user, model.Password);
                //if (_signInManager.UserManager.Users.Any())
                //{
                //    await _signInManager.UserManager.AddToRoleAsync(user, "Administrator");
                //}
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return this.RedirectToAction("Login", "Users");
                }
            }
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginInputModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Username);
                if (user != null)
                {
                    SignInResult signInResult =
                        await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
                    if (signInResult.Succeeded)
                    {
                        return this.RedirectToAction("Index", "Home");
                    }
                }
             // TODO : Compare input password with password in database . If any error print message - "Incorrect password or username."
            }
            
            return this.View();
        }
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return this.Redirect("/");
        }
    }
}