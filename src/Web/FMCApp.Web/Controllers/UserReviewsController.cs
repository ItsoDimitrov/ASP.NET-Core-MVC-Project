using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FMCApp.Data;
using FMCApp.Data.Models;
using FMCApp.Web.Models.ViewModels.InputModels;
using FMCApp.Web.Models.ViewModels.VisualizationModels.Comments;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FMCApp.Web.Controllers
{
    public class UserReviewsController : Controller
    {
        private readonly FMCAppContext _context;
        private readonly UserManager<FMCAppUser> _userManager;
        public UserReviewsController(FMCAppContext context, UserManager<FMCAppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        public IActionResult Comments(int id)
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
                AddedOn = c.AddedOn

            });
            var viewModel = new AllCommentsViewModel
            {
                Comments = comments
            };
            ViewBag.MovieTitle = movie.Title;
            ViewData["MovieId"] = movie.Id;
            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddComments(AllCommentsViewModel model, int movieId)
        {
            
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Comments","UserReviews", new
                {
                    id = movieId
                });
            }
            if (!User.Identity.IsAuthenticated)
            {
                return this.RedirectToAction("Register","Users");
            }

            var currentLoggedInUserId = this._userManager.GetUserId(HttpContext.User);
            var comment = new Comment
            {
                UserId = currentLoggedInUserId,
                Content = model.Comment.Content,
                MovieId = movieId,
                AddedOn = DateTime.UtcNow
                    

            };
            this._context.Comments.Add(comment);
            this._context.SaveChanges();
            return this.RedirectToAction("Comments", "UserReviews", new
            {
                Id = movieId
            });
        }

    }
}