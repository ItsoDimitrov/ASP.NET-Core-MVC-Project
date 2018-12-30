using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMCApp.Web.Models.ViewModels.VisualizationModels.Movies
{
    public class MoviesViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string MoviePosterUrl { get; set; }
    }
}
