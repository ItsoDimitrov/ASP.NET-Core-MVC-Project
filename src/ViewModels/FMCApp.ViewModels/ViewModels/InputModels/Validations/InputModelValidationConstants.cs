using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMCApp.Web.Models.ViewModels.InputModels.Validations
{
    public class InputModelValidationConstants
    {
        protected const string USERNAME_MAX_LENGTH_ERRORMESSAGE = "Your Username Is Too Long.";
        protected const string USERNAME_MIN_LENGTH_ERRORMESSAGE = "Your Username Is Too Short.";
        protected const string REQUIRED_USERNAME_ERRORMESSAGE = "Username cannot be null or whitespace.";
        protected const string PASSWORD_COMPARE_ERRORMESSAGE = "Password does not match the confirm password.";
        protected const string COMMENT_CONTENT_MIN_LENGTH_ERRORMESSAGE = "Too Short Comment Size.";
        protected const string COMMENT_CONTENT_MAX_LENGTH_ERRORMESSAGE = "Too Long Comment Size.";
        protected const string COMMENT_CONTENT_REQUIRED__ERRORMESSAGE = "Comment cannot be null or whitespace.";

        protected const string MOVIE_TITLE_REQUIRED_ERRORMESSAGE = "Movie Title cannot be null or whitespace.";
        protected const string MOVIE_GENRE_REQUIRED_ERRORMESSAGE = "Movie Genre cannot be null or whitespace.";
        protected const string MOVIE_DESCRIPTION_REQUIRED_ERRORMESSAGE = "Movie Description cannot be null or whitespace.";
        protected const string MOVIE_DIRECTOR_REQUIRED_ERRORMESSAGE = "Movie Director cannot be null or whitespace.";
        protected const string MOVIE_RELEASE_DATE_REQUIRED_ERRORMESSAGE = "Movie Release date cannot be null or whitespace.";
        protected const string MOVIE_POSTER_URL_REQUIRED_ERRORMESSAGE = "Movie Poster URL cannot be null or whitespace.";


    }
}
