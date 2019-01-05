using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FMCApp.Web.Models.ViewModels.VisualizationModels.Comments;

namespace FMCApp.Services.Interfaces
{
    public interface IUserReviewsService
    {
        void AddComment(AllCommentsViewModel model, int movieId);
    }
}
