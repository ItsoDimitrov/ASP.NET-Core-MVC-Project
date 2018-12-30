using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FMCApp.Data;
using FMCApp.Web.Models.ViewModels.VisualizationModels.Movies;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace FMCApp.Web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly FMCAppContext _context;

        public MoviesController(FMCAppContext context)
        {
            _context = context;
        }

        public IActionResult AllMovies(int? pageNumber)
        {
            var movie = this._context.Movies.Select(m => new MoviesViewModel
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
            return this.View(pagedViewModel);
            //  return this.View(moviesModel);
        }

        public IActionResult Details(int? id)
        {
            var movieCheck = this._context.Movies.Find(id);
            if (movieCheck == null)
            {
                return NotFound();
            }

            var movie = this._context.Movies.Select(m => new MovieDetailsViewModel
            {
                Id = m.Id,
                Title = m.Title,
                Director = m.Director.Name,
                Description = m.Description,
                Genre = m.Genre.ToString(),
                ReleaseDate = m.ReleaseDate,
                MoviePosterUrl = m.MoviePosterUrl,


            }).FirstOrDefault(m => m.Id == id);
            return View("Details",movie); // TODO : Implement view correctly ! ! ! !
        }
    }
}