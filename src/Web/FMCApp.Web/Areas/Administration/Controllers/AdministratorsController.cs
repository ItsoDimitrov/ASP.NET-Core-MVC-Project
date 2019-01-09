using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FMCApp.Data;
using FMCApp.Data.Models;
using FMCApp.Data.Models.Enums;
using FMCApp.ViewModels.ViewModels.InputModels;
using FMCApp.ViewModels.ViewModels.VisualizationModels.Administration;
using FMCApp.ViewModels.ViewModels.VisualizationModels.Shared;
using FMCApp.ViewModels.ViewModels.VisualizationModels.Users.Administration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FMCApp.Web.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "Administrator")]
    public class AdministratorsController : Controller
    {
        private readonly FMCAppContext _context;
        public AdministratorsController(FMCAppContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult AddMovie()
        {
            var directors = this._context.Directors.Select(d => new AddMovieDirectorViewModel
            {
                DirectorId = d.Id,
                DirectorName = d.Name
            });
            var genres = Enum.GetValues(typeof(Genre)).Cast<Genre>().Select(g => new AddMovieGenreViewModel
            {
                Id = (int)g,
                Genre = g.ToString()
            });

            var viewModel = new AdminAddMovieViewModel
            {
                Directors = directors,
                Genres = genres
            };
            ViewBag.Model = viewModel;
            return this.View();
        }
        [HttpPost]
        public IActionResult AddMovie(AddMovieInputModel model)
        {
            
            
            if (this.ModelState.IsValid)
            {
                //var movie = new Movie
                //{
                //    Id = 
                //}
            }

            return this.View();
        }

        [HttpGet]
        public IActionResult AllUsers()
        {
            var users = this._context.Users.Select(u => new UsersViewModel
            {
                Id =  u.Id,
                Email = u.Email,
                Username = u.UserName

            });
            var model = new AllUsersViewModel
            {
                Users = users
            };
            // TODO : Service need to be added 
            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteUser(string id)
        {
            var userToDelete = this._context.Users.FirstOrDefault(u => u.Id == id);
            if (userToDelete == null)
            {
                return NotFound();
            }

            this._context.Users.Remove(userToDelete);
            this._context.SaveChanges();
            return this.RedirectToAction("AllUsers", "Administrators");
        }
    }
}
