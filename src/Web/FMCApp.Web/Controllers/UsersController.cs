﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FMCApp.Data;
using FMCApp.Data.Models;
using FMCApp.Services.Interfaces;
using FMCApp.ViewModels.ViewModels.VisualizationModels.Users;
using FMCApp.Web.Models.ViewModels.InputModels;
using FMCApp.Web.Models.ViewModels.VisualizationModels.Watchlist;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using X.PagedList;

namespace FMCApp.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly SignInManager<FMCAppUser> _signInManager;
        private readonly IUserService _userService;
        private readonly FMCAppContext _context;

        public UsersController(SignInManager<FMCAppUser> signInManager, IUserService userService, FMCAppContext context)
        {
            _signInManager = signInManager;
            _userService = userService;
            _context = context;
        }


        [HttpGet]
        [Authorize]
        public IActionResult Comments()
        {
            var currentLoggedInUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userComments = this._context.Comments.Where(u => u.UserId == currentLoggedInUserId).Select(c =>
                new UserCommentViewModel
                {
                    MovieId = c.Movie.Id,
                    MovieTitle = c.Movie.Title,
                    MovieGenre = c.Movie.Genre.ToString(),
                    MovieUserComments = c.Movie.Comments.Count(u => u.UserId == currentLoggedInUserId)
                });

            
            var viewModel = new UserCommentsViewModel
            {
                UserComments = userComments
            };
            return this.View(viewModel);
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return this.RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {

            if (User.Identity.IsAuthenticated)
            {
                return this.RedirectToAction("Index", "Home");
            }
            return this.View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public  async Task<IActionResult> Register(RegisterInputModel model)
        {
            if (ModelState.IsValid)
            {
                //var user = new FMCAppUser
                //{
                //    UserName = model.Username,
                //    Email = model.Email,

                //};
                //var result = await _userManager.CreateAsync(user, model.Password);
                ////if (_signInManager.UserManager.Users.Any())
                ////{
                ////    await _signInManager.UserManager.AddToRoleAsync(user, "Administrator");
                ////}
                var registerResult = _userService.RegisterUser(model);
                if (registerResult.Result.Succeeded)
                {
                    return this.RedirectToAction("Login", "Users");
                }
            }
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Login(LoginInputModel model)
        {
            if (ModelState.IsValid)
            {
                //var user = await _userManager.FindByNameAsync(model.Username);
                //if (user != null)
                //{
                //    SignInResult signInResult =
                //        await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
                var signInResult =  _userService.LogUser(model);
                    if (signInResult.Succeeded)
                    {
                        return this.RedirectToAction("Index", "Home");
                    }
                //}
                // TODO : Compare input password with password in database . If any error print message - "Incorrect password or username."
            }
            
            return this.View();
        }
        [Authorize]
        public IActionResult Watchlist(int id)
        {
            // Get the current logged in user 
            //var currentUser = _userManager.GetUserId(HttpContext.User);
            //var userMovies = this._context.WatchLists.Where(u => u.UserId == currentUser).Select(m => new UserWatchlistViewModel
            //{
            //    Id =  m.Id,
            //    MoviePosterUrl = m.Movie.MoviePosterUrl,
            //    AddedOn = DateTime.UtcNow,
            //    MovieTitle = m.Movie.Title,
            //    Genre = m.Movie.Genre.ToString(),
            //    Description = m.Movie.Description
            //});
            var userMovies = this._userService.Watchlist();
            var model = new AllUserWatchlistViewModel
            {
                userWatchlist = userMovies
            };
            return this.View(model);
        }

        [Authorize]
        [HttpPost]
        public IActionResult RemoveFromWatchlist(int id)
        {
            //var currentUser = _userManager.GetUserId(HttpContext.User);
            //var movieToDelete = this._context.WatchLists.FirstOrDefault(m => m.Id == id && m.UserId == currentUser);
            //if (movieToDelete == null)
            //{
            //    return this.NotFound();
            //}

            //this._context.Remove(movieToDelete);
            //this._context.SaveChanges();
            _userService.RemoveFromWatchlist(id);
            return this.RedirectToAction("Watchlist","Users");
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return this.Redirect("/");
        }
    }
}