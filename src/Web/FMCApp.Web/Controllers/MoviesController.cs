using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FMCApp.Data;
using FMCApp.Data.Models;
using FMCApp.Services.Interfaces;
using FMCApp.Web.Models.ViewModels.VisualizationModels.Comments;
using FMCApp.Web.Models.ViewModels.VisualizationModels.Movies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace FMCApp.Web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly FMCAppContext _context;
        private readonly UserManager<FMCAppUser> _userManager;
        private readonly IMovieService _movieService;
        public MoviesController(FMCAppContext context, UserManager<FMCAppUser> userManager, IMovieService movieService)
        {
            _context = context;
            _userManager = userManager;
            _movieService = movieService;
        }

        public async Task<IActionResult> AllMovies(int? pageNumber, string searchString)
        {

            var movie = this._context.Movies.OrderByDescending(m => m.Id).Select(m => new MoviesViewModel
            {
                Id = m.Id,
                Title = m.Title,
                MoviePosterUrl = m.MoviePosterUrl
            });
            var moviesModel = new AllMoviesViewModel
            {
                 Movies = movie
            };
            var nextPage = pageNumber ?? 1;
            var pagedViewModel = moviesModel.Movies.ToPagedList(nextPage, 6);

           

            if (!String.IsNullOrEmpty(searchString))
            {
                movie = movie.Where(s => s.Title.Contains(searchString));
                return View("SearchMovie",await movie.ToListAsync());
            }

            return this.View(pagedViewModel);
            //  return this.View(moviesModel);

        }

        public IActionResult Details(int? id)
        {
            //var movieCheck = this._context.Movies.Find(id);
            //if (movieCheck == null)
            //{
            //    return NotFound();
            //}

            //var movie = this._context.Movies.Select(m => new MovieDetailsViewModel
            //{
            //    Id = m.Id,
            //    Title = m.Title,
            //    Director = m.Director.Name,
            //    Description = m.Description,
            //    Genre = m.Genre.ToString(),
            //    ReleaseDate = m.ReleaseDate,
            //    MoviePosterUrl = m.MoviePosterUrl,


            //}).FirstOrDefault(m => m.Id == id);
            var movieModel = this._movieService.GetAllMoviesModel(id);
            return View("Details",movieModel); // TODO : Implement view correctly ! ! ! !
        }

       
        //[Authorize]
        [HttpPost]
        public IActionResult AddToWatchlist(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return this.RedirectToAction("Register", "Users");
            }
            var movieObject = this._context.Movies.FirstOrDefault(m => m.Id == id);
            if (movieObject == null)    
            {
                return this.NotFound();
            }

            string userId = this._userManager.GetUserId(HttpContext.User);
            var user = this._context.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                return this.RedirectToAction("Register", "Users");
            }

        
            var watchlist = new WatchList
            {
                AddedOn = DateTime.UtcNow,
                FmcAppUser = user,
                Movie = movieObject

            };
            var movieModel = this._context.Movies.Select(m => new MovieDetailsViewModel
            {
                Id = m.Id,
                Title = m.Title,
                Director = m.Director.Name,
                Description = m.Description,
                Genre = m.Genre.ToString(),
                ReleaseDate = m.ReleaseDate,
                MoviePosterUrl = m.MoviePosterUrl,


            }).FirstOrDefault(m => m.Id == id);
            var duplcateChecker = this._context.WatchLists.Any(c => c.UserId == userId && c.MovieId == movieObject.Id);
            if (duplcateChecker)
            {
                ViewBag.message = "Already Added";
                return this.View("Details", movieModel);

            }
            this._context.Add(watchlist);
            this._context.SaveChanges();
            return this.View("Details", movieModel);
        }
    }
}