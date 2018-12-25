using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FMCApp.Data;
using FMCApp.Web.Models.ViewModels.VisualizationModels.News;
using Microsoft.AspNetCore.Mvc;

namespace FMCApp.Web.Controllers
{
    public class NewsController : Controller
    {
        private readonly FMCAppContext _context;

        public NewsController(FMCAppContext context)
        {
            _context = context;
        }

        public IActionResult Details(int? id)
        {
            var news = this._context.Newses.Find(id);
            if (news == null)
            {
                return NotFound();
            }
            
            var newsModel = this._context.Newses.Select(n => new NewsDetails
            {
                 Id = n.Id,
                 Content = n.Content,
                Title = n.Title,
                ImageUrl = n.ImageUrl
            }).FirstOrDefault(n => n.Id == id);
            return View("Details",newsModel);
        }
    }
}