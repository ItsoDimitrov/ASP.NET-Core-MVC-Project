using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FMCApp.Data;
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
