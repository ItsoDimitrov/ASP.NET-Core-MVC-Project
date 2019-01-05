using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FMCApp.Web.Models.ViewModels.VisualizationModels.IndexMovies;
using FMCApp.Web.Models.ViewModels.VisualizationModels.IndexNews;

namespace FMCApp.Web.Models.ViewModels.VisualizationModels.Shared
{
    public class IndexNewsMoviesViewModel
    {
        public IndexNewsMoviesViewModel()
        {
            this.Newses = new HashSet<IndexNewsViewModel>();
            this.Movies = new HashSet<IndexMovieViewModel>();
        }
        public IEnumerable<IndexNewsViewModel> Newses { get; set; }
        public IEnumerable<IndexMovieViewModel> Movies { get; set; }
    }
}
