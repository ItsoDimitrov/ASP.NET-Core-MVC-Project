using System;
using System.Collections.Generic;
using System.Text;

namespace FMCApp.ViewModels.ViewModels.VisualizationModels.Users
{
    public class UserCommentViewModel
    {
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public string MovieGenre { get; set; }
        public int MovieUserComments { get; set; }
    }
}
