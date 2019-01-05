using System.Collections.Generic;
using System.Linq;
using FMCApp.Data;
using FMCApp.Services.Interfaces;
using FMCApp.Web.Models.ViewModels.VisualizationModels.News;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using  X.PagedList;
namespace FMCApp.Web.Controllers
{
    public class NewsController : Controller
    {
        private readonly FMCAppContext _context;
        private readonly INewsService _newsService;
        public NewsController(FMCAppContext context, INewsService newsService)
        {
            _context = context;
            _newsService = newsService;
        }

        public IActionResult AllNews(int? pageNumber)
        {

            var news = this._newsService.GetAllNews();
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
            //var news = this._context.Newses.Find(id);
            //if (news == null)
            //{
            //    return NotFound();
            //}
            
            //var newsModel = this._context.Newses.Select(n => new NewsDetailsViewModel
            //{
            //     Id = n.Id,
            //     Content = n.Content,
            //    Title = n.Title,
            //    ImageUrl = n.ImageUrl
            //}).FirstOrDefault(n => n.Id == id);
            var newsModel = this._newsService.GetModel(id);
            return View("Details",newsModel);
        }
    }
}