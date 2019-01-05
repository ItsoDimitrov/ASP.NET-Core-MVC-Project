using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMCApp.Web.Models.ViewModels.VisualizationModels.News
{
    public class NewsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }

    }
}
