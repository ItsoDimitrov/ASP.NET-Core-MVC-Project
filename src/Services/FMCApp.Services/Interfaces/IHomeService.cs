using System;
using System.Collections.Generic;
using System.Text;
using FMCApp.Web.Models.ViewModels.VisualizationModels.Shared;

namespace FMCApp.Services.Interfaces
{
    public interface IHomeService
    {
        IndexNewsMoviesViewModel GetIndexModelInfo();
    }
}
