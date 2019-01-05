using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FMCApp.Data;
using FMCApp.Data.Models;
using FMCApp.Services.Interfaces;
using FMCApp.Web.Models.ViewModels.InputModels;
using Microsoft.AspNetCore.Identity;

namespace FMCApp.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<FMCAppUser> _userManager;
        private readonly SignInManager<FMCAppUser> _signInManager;
        private readonly FMCAppContext _context;

        public UserService(UserManager<FMCAppUser> userManager, SignInManager<FMCAppUser> signInManager, FMCAppContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        public SignInResult LogUser(LoginInputModel model)
        {
            var user = _userManager.FindByNameAsync(model.Username).Result;
            if (user == null)
            {
                return SignInResult.Failed;
                
            }
                SignInResult signInResult = 
                     _signInManager.PasswordSignInAsync(user, model.Password, false, false).Result;

            return signInResult;

        }

        public async Task<IdentityResult> RegisterUser(RegisterInputModel model)
        {
            var user = new FMCAppUser
            {
                UserName = model.Username,
                Email = model.Email,

            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {

                await _signInManager.SignInAsync(user, false);
                return result;

            }
            return IdentityResult.Failed();
        }
    }
}
