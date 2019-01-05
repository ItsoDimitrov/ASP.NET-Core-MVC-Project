using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FMCApp.Web.Models.ViewModels.InputModels.Validations;

namespace FMCApp.Web.Models.ViewModels.InputModels
{
    public class CommentsInputModel : InputModelValidationConstants
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = COMMENT_CONTENT_REQUIRED__ERRORMESSAGE)]
        [StringLength(50, ErrorMessage = COMMENT_CONTENT_MAX_LENGTH_ERRORMESSAGE)]
        [MinLength(5, ErrorMessage = COMMENT_CONTENT_MIN_LENGTH_ERRORMESSAGE)]
        [Display(Name = "Content")]
        public string Content { get; set; }
    }
}
