using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FMCApp.Data;
using FMCApp.Data.Models;
using FMCApp.Services.Interfaces;
using FMCApp.Web.Models.ViewModels.VisualizationModels.IndexMovies;
using FMCApp.Web.Models.ViewModels.VisualizationModels.IndexNews;
using FMCApp.Web.Models.ViewModels.VisualizationModels.Shared;
using Microsoft.AspNetCore.Identity;

namespace FMCApp.Services
{
    public class HomeService : BaseService ,IHomeService
    {
        public HomeService(FMCAppContext context, UserManager<FMCAppUser> userManager) : base(context, userManager)
        {
        }

        public IndexNewsMoviesViewModel GetIndexModelInfo()
        {
            var news = this._context.Newses.Take(2)
                .Select(n => new IndexNewsViewModel
                {
                    Id = n.Id,
                    Title = n.Title,
                    Content = n.Content,
                });

            var movie = this._context.Movies.Take(6)
                .Select(m => new IndexMovieViewModel
                {
                    Id = m.Id,
                    Title = m.Title,
                    MoviePosterUrl = m.MoviePosterUrl
                });

            var model = new IndexNewsMoviesViewModel // shared class needed . Multiple models is given to the view
            {
                Newses = news,
                Movies = movie
            }; // TODO : Think about smart way ( dynamic or tuple )
            return model;
        }
    }
}
