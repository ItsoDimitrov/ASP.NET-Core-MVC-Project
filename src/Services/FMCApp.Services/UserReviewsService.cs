using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using FMCApp.Data;
using FMCApp.Data.Models;
using FMCApp.Services.Interfaces;
using FMCApp.Web.Models.ViewModels.VisualizationModels.Comments;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace FMCApp.Services
{
    public class UserReviewsService : BaseService, IUserReviewsService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserReviewsService(FMCAppContext context, UserManager<FMCAppUser> userManager, IHttpContextAccessor httpContextAccessor) : base(context, userManager)
        {
            _httpContextAccessor = httpContextAccessor;
        }


        public void AddComment(AllCommentsViewModel model, int movieId)
        {
            var currentLoggedInUserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var comment = new Comment
            {
                UserId = currentLoggedInUserId,
                Content = model.Comment.Content,
                MovieId = movieId,
                AddedOn = DateTime.UtcNow


            };
            this._context.Comments.Add(comment);
            this._context.SaveChanges();
        }
    }
}
