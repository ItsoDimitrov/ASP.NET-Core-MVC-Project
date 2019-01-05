using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FMCApp.Data;
using FMCApp.Data.Models;
using FMCApp.Services.Interfaces;
using FMCApp.Web.Models.ViewModels.InputModels;
using FMCApp.Web.Models.ViewModels.VisualizationModels.Watchlist;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace FMCApp.Services
{
    public class UserService : BaseService,IUserService
    {
        //private readonly UserManager<FMCAppUser> _userManager;
        private readonly SignInManager<FMCAppUser> _signInManager;
        //private readonly FMCAppContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public UserService(UserManager<FMCAppUser> userManager, SignInManager<FMCAppUser> signInManager, FMCAppContext context
            , IHttpContextAccessor httpContextAccessor) : base(context,userManager)
        {
            //_userManager = userManager;
            _signInManager = signInManager;
            //_context = context;
            _httpContextAccessor = httpContextAccessor;
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

        public IQueryable<UserWatchlistViewModel> Watchlist()
        {
            //var currentUser = _userManager.GetUserId(HttpContext.User);
            var currentUser = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var userMovies = this._context.WatchLists.Where(u => u.UserId == currentUser).Select(m => new UserWatchlistViewModel
            {
                Id = m.Id,
                MoviePosterUrl = m.Movie.MoviePosterUrl,
                AddedOn = DateTime.UtcNow,
                MovieTitle = m.Movie.Title,
                Genre = m.Movie.Genre.ToString(),
                Description = m.Movie.Description
            });
            return userMovies;
        }

        public void RemoveFromWatchlist(int id)
        {
            var currentUser = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var movieToDelete = this._context.WatchLists.FirstOrDefault(m => m.Id == id && m.UserId == currentUser);
            if (movieToDelete == null)
            {
                throw new InvalidOperationException("Invalid id");
            }

            this._context.Remove(movieToDelete);
            this._context.SaveChanges();
        }
    }
}
