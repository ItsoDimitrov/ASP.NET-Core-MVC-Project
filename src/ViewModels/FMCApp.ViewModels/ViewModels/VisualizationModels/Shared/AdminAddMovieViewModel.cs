using System;
using System.Collections.Generic;
using System.Text;
using FMCApp.ViewModels.ViewModels.VisualizationModels.Administration;
using FMCApp.Web.Models.ViewModels.VisualizationModels.IndexMovies;
using FMCApp.Web.Models.ViewModels.VisualizationModels.IndexNews;

namespace FMCApp.ViewModels.ViewModels.VisualizationModels.Shared
{
    public class AdminAddMovieViewModel
    {
        public AdminAddMovieViewModel()
        {
            this.Directors = new HashSet<AddMovieDirectorViewModel>();
            this.Genres = new HashSet<AddMovieGenreViewModel>();

        }
        public IEnumerable<AddMovieDirectorViewModel> Directors { get; set; }
        public IEnumerable<AddMovieGenreViewModel> Genres { get; set; }
    }
}
