using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FMCApp.Data;
using FMCApp.Web.Models.ViewModels.VisualizationModels.Movies;
using Microsoft.AspNetCore.Mvc;

namespace FMCApp.Web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly FMCAppContext _context;

        public MoviesController(FMCAppContext context)
        {
            _context = context;
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