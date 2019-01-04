using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FMCApp.Data;
using FMCApp.Web.Models.ViewModels.VisualizationModels.Comments;
using Microsoft.AspNetCore.Mvc;

namespace FMCApp.Web.Controllers
{
    public class UserReviewsController : Controller
    {
        private readonly FMCAppContext _context;

        public UserReviewsController(FMCAppContext context)
        {
            _context = context;
        }


        public IActionResult UserReviews(int id)
        {
            var movie = this._context.Movies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            var comments = this._context.Comments.Where(m => m.MovieId == movie.Id).Select(c => new CommentViewModel
            {
                Id = c.Id,
                Username = c.FmcAppUser.UserName,
                Content = c.Content,

            });
            var viewModel = new AllCommentsViewModel
            {
                Comments = comments
            };
            ViewBag.MovieTitle = movie.Title;
            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UserReviews(string item)
        {
            return this.View();
        }

    }
}