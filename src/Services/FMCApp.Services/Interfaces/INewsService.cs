using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FMCApp.Web.Models.ViewModels.VisualizationModels.News;

namespace FMCApp.Services.Interfaces
{
    public interface INewsService
    {
        IQueryable<NewsViewModel> GetAllNews();
        NewsDetailsViewModel GetModel(int? id);
    }
}
