﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMCApp.Web.Models.ViewModels.VisualizationModels.Movies
{
    public class AllMoviesViewModel
    {
        public AllMoviesViewModel()
        {
            this.Movies = new HashSet<MoviesViewModel>();
        }

        public IEnumerable<MoviesViewModel> Movies { get; set; }
    }
}
