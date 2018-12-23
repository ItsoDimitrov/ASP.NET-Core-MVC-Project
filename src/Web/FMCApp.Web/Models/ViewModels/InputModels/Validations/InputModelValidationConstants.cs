using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMCApp.Web.Models.ViewModels.InputModels.Validations
{
    public class InputModelValidationConstants
    {
        protected const string USERNAME_MAX_LENGTH_ERRORMESSAGE = "Your Username Is Too Long";
        protected const string USERNAME_MIN_LENGTH_ERRORMESSAGE = "Your Username Is Too Short";
        protected const string REQUIRED_USERNAME_ERRORMESSAGE = "Username cannot be null or whitespace";
        protected const string PASSWORD_COMPARE_ERRORMESSAGE = "Password does not match the confirm password.";
    }
}
