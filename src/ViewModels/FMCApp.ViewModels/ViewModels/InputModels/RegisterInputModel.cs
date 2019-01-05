using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FMCApp.Web.Models.ViewModels.InputModels.Validations;

namespace FMCApp.Web.Models.ViewModels.InputModels
{
    public class RegisterInputModel : InputModelValidationConstants
      {
    //    private const string USERNAME_MAX_LENGTH_ERRORMESSAGE = "Your Username Is Too Long";
    //    private const string USERNAME_MIN_LENGTH_ERRORMESSAGE = "Your Username Is Too Short";
    //    private const string REQUIRED_USERNAME_ERRORMESSAGE = "Username cannot be null or whitespace";
    //    private const string PASSWORD_COMPARE_ERRORMESSAGE = "Password does not match the confirm password.";

        [Required(AllowEmptyStrings = false,ErrorMessage = REQUIRED_USERNAME_ERRORMESSAGE)]
        [StringLength(10, ErrorMessage = USERNAME_MAX_LENGTH_ERRORMESSAGE)]
        [MinLength(3,ErrorMessage = USERNAME_MIN_LENGTH_ERRORMESSAGE)]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        // TODO: Minimum and maximum length for password need to be added.
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare(nameof(Password),ErrorMessage = PASSWORD_COMPARE_ERRORMESSAGE)]
        public string ConfirmPassword { get; set; }

    }
}
