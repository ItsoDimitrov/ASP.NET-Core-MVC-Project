using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using FMCApp.Data;
using FMCApp.Services.Interfaces;
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
        private readonly IHomeService _homeService;
        public HomeController(FMCAppContext context, IHomeService homeService)
        {
            _homeService = homeService;
        }
        public IActionResult Index()
        {
            var model = this._homeService.GetIndexModelInfo();
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
