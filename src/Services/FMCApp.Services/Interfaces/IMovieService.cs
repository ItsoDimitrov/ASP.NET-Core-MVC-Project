using System;
using System.Collections.Generic;
using System.Text;
using FMCApp.Web.Models.ViewModels.VisualizationModels.Movies;

namespace FMCApp.Services.Interfaces
{
    public  interface IMovieService
    {
        MovieDetailsViewModel GetAllMoviesModel(int? id);
    }
}
