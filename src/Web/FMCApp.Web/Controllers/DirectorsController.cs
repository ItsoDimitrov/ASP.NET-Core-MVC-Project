using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FMCApp.Data;
using FMCApp.ViewModels.ViewModels.VisualizationModels.Directors;
using Microsoft.AspNetCore.Mvc;

namespace FMCApp.Web.Controllers
{
    public class DirectorsController : Controller
    {
        private readonly FMCAppContext _context;

        public DirectorsController(FMCAppContext context)
        {
            _context = context;
        }

        public IActionResult Details(string directorName)
        {
            var directorExist = this._context.Directors.FirstOrDefault(d => d.Name == directorName);
            if (directorExist == null)
            {
                return NotFound();
            }

            var directorModel = this._context.Directors.Select(d => new DirectorViewModel
            {
                Name = d.Name,
                Info = d.Info,
                BirthDate = d.Birthdate
            }).FirstOrDefault(d => d.Name == directorName);

            return this.View(directorModel);
        }
    }
}