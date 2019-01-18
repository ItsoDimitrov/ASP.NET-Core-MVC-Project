using System;
using System.Collections.Generic;
using System.Text;

namespace FMCApp.ViewModels.ViewModels.VisualizationModels.Users
{
    public class UserCommentsViewModel
    {
        public UserCommentsViewModel()
        {
            this.UserComments = new HashSet<UserCommentViewModel>();
        }

        public IEnumerable<UserCommentViewModel> UserComments { get; set; }
    }
}
