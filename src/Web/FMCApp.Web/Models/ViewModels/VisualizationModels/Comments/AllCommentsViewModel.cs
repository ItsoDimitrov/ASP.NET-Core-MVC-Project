using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMCApp.Web.Models.ViewModels.VisualizationModels.Comments
{
    public class AllCommentsViewModel
    {
        public AllCommentsViewModel()
        {
            this.Comments = new HashSet<CommentViewModel>();
        }
        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}
