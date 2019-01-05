using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FMCApp.Web.Models.ViewModels.InputModels;
using FMCApp.Web.Models.ViewModels.InputModels.Validations;

namespace FMCApp.Web.Models.ViewModels.VisualizationModels.Comments
{
    public class AllCommentsViewModel : InputModelValidationConstants
    {
        public AllCommentsViewModel()
        {
            this.Comments = new HashSet<CommentViewModel>();
        }

        public IEnumerable<CommentViewModel> Comments { get; set; }
        public CommentsInputModel Comment { get; set; }
    }
}
