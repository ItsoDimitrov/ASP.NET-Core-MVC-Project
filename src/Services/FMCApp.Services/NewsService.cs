using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FMCApp.Data;
using FMCApp.Data.Models;
using FMCApp.Services.Interfaces;
using FMCApp.Web.Models.ViewModels.VisualizationModels.News;
using Microsoft.AspNetCore.Identity;

namespace FMCApp.Services
{
    public class NewsService : BaseService, INewsService
    {
        public NewsService(FMCAppContext context, UserManager<FMCAppUser> userManager) : base(context, userManager)
        {
        }

        public IQueryable<NewsViewModel> GetAllNews()
        {
            var news = _context.Newses.Select(n => new NewsViewModel
            {
                Id = n.Id,
                Content = n.Content,
                Title = n.Title,
                ImageUrl = n.ImageUrl
            });
            return news;
        }

        public NewsDetailsViewModel GetModel(int? id)
        {
            var news = this._context.Newses.Find(id);
            //if (news == null)
            //{
            //    return NotFound();
            //}

            var newsModel = this._context.Newses.Select(n => new NewsDetailsViewModel
            {
                Id = n.Id,
                Content = n.Content,
                Title = n.Title,
                ImageUrl = n.ImageUrl
            }).FirstOrDefault(n => n.Id == id);
            return newsModel;
        }
    }
}
