using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FMCApp.Web.Models.ViewModels.InputModels.Validations;

namespace FMCApp.Web.Models.ViewModels.InputModels
{
    public class LoginInputModel : InputModelValidationConstants
    {

        [Required(AllowEmptyStrings = false, ErrorMessage = REQUIRED_USERNAME_ERRORMESSAGE)]
        [StringLength(10, ErrorMessage = USERNAME_MAX_LENGTH_ERRORMESSAGE)]
        [MinLength(3, ErrorMessage = USERNAME_MIN_LENGTH_ERRORMESSAGE)]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
