using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using FMCApp.Data;
using Microsoft.AspNetCore.Mvc;
using FMCApp.Web.Models;
using FMCApp.Web.Models.ViewModels.VisualizationModels;
using FMCApp.Web.Models.ViewModels.VisualizationModels.IndexMovies;
using FMCApp.Web.Models.ViewModels.VisualizationModels.IndexNews;
using FMCApp.Web.Models.ViewModels.VisualizationModels.Shared;
using Microsoft.IdentityModel.Xml;

namespace FMCApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly FMCAppContext _context;

        public HomeController(FMCAppContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var news = this._context.Newses.Take(2)
                .Select(n => new IndexNewsViewModel
            {
                Id = n.Id,
                Title = n.Title,
                Content = n.Content,
            });
            //var newsesModel = new IndexNewsesViewModel
            //{
            //    Newses = news,
              
                
            //};
            var movie = this._context.Movies.Take(6)
                .Select(m => new IndexMovieViewModel
                {
                    Id = m.Id,
                    Title = m.Title,
                    MoviePosterUrl = m.MoviePosterUrl
                });
            //var moviesModel = new IndexMoviesViewModel  
            //{
            //    Movies = movie
            //};
            var model = new IndexNewsMoviesViewModel // shared class needed . Multiple models is given to the view
            {
                Newses = news,
                Movies = movie
            }; // TODO : Think about smart way ( dynamic or tuple )
            return View(model);
        }

        
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
