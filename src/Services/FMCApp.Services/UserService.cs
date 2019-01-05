using System;
using System.Collections.Generic;
using System.Text;
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
        public UserService(UserManager<FMCAppUser> userManager, SignInManager<FMCAppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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
    }
}
