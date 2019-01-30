using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FMCApp.Data;
using FMCApp.Data.Models;
using FMCApp.Services.Interfaces;
using FMCApp.Web.Models.ViewModels.InputModels;
using FMCApp.Web.Models.ViewModels.VisualizationModels.Comments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FMCApp.Web.Controllers
{
    public class UserReviewsController : Controller
    {
        private readonly FMCAppContext _context;
        private readonly IUserReviewsService _userReviewsService;
        public UserReviewsController(FMCAppContext context, IUserReviewsService userReviewsService)
        {
            _context = context;
            _userReviewsService = userReviewsService;
        }


        public IActionResult Comments(int id)
        {
            var movie = this._context.Movies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            var comments = this._context.Comments.OrderByDescending(d => d.AddedOn).Where(m => m.MovieId == movie.Id).Select(c => new CommentViewModel
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
            
            this._userReviewsService.AddComment(model,movieId);
            return this.RedirectToAction("Comments", "UserReviews", new
            {
                Id = movieId
            });
        }

        [HttpPost]
        [Authorize]
        public IActionResult DeleteComment(int id)
        {
            return this.RedirectToAction("Comments", "UserReviews");
        }
 
       
    }
}