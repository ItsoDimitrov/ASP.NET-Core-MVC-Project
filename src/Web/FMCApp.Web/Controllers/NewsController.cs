using System.Collections.Generic;
using System.Linq;
using FMCApp.Data;
using FMCApp.Web.Models.ViewModels.VisualizationModels.News;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using  X.PagedList;
namespace FMCApp.Web.Controllers
{
    public class NewsController : Controller
    {
        private readonly FMCAppContext _context;

        public NewsController(FMCAppContext context)
        {
            _context = context;
        }

        public IActionResult AllNews(int? pageNumber)
        {
            var news = _context.Newses.Select(n => new NewsViewModel
            {
                Id = n.Id,
                Content = n.Content,
                Title = n.Title,
                ImageUrl = n.ImageUrl
            });
           

            var newsesModel = new AllNewsesViewModel
            {
                Newses = news
            };
            var nextPage = pageNumber ?? 1;
            var pagedViewModel = newsesModel.Newses.ToPagedList(nextPage,3);
            return this.View(pagedViewModel);

        }

        public IActionResult Details(int? id)
        {
            var news = this._context.Newses.Find(id);
            if (news == null)
            {
                return NotFound();
            }
            
            var newsModel = this._context.Newses.Select(n => new NewsDetailsViewModel
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