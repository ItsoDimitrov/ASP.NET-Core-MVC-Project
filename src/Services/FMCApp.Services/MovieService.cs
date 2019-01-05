using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FMCApp.Data;
using FMCApp.Data.Models;
using FMCApp.Services.Interfaces;
using FMCApp.Web.Models.ViewModels.VisualizationModels.Movies;
using Microsoft.AspNetCore.Identity;

namespace FMCApp.Services
{
    public class MovieService : BaseService, IMovieService
    {
        public MovieService(FMCAppContext context, UserManager<FMCAppUser> userManager) : base(context, userManager)
        {
        }

        public MovieDetailsViewModel GetAllMoviesModel(int? id)
        {
            var movieCheck = this._context.Movies.Find(id);
            //if (movieCheck == null)
            //{
            //    return NotFound();
            //}

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
            return movie;
            
        }

    }
}
