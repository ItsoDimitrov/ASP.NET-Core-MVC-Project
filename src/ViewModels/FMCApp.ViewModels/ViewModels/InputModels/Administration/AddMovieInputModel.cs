using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using FMCApp.Data.Models.Enums;
using FMCApp.Web.Models.ViewModels.InputModels.Validations;

namespace FMCApp.ViewModels.ViewModels.InputModels
{
    public class AddMovieInputModel : InputModelValidationConstants
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = MOVIE_TITLE_REQUIRED_ERRORMESSAGE)]
        [Display(Name = "Title")]
        public string Title  { get; set; }

        [Required(AllowEmptyStrings = false,ErrorMessage = MOVIE_GENRE_REQUIRED_ERRORMESSAGE)]
        [Display(Name = "Genre")]
        public int Genre { get; set; }

        [Required(AllowEmptyStrings = false,ErrorMessage = MOVIE_DESCRIPTION_REQUIRED_ERRORMESSAGE)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = MOVIE_DIRECTOR_REQUIRED_ERRORMESSAGE)]
        [Display(Name = "DirectorId")]
        public int DirectorId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = MOVIE_RELEASE_DATE_REQUIRED_ERRORMESSAGE)]
        [Display(Name = "ReleaseDate")]
        public DateTime ReleaseDate { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = MOVIE_POSTER_URL_REQUIRED_ERRORMESSAGE)]
        [Display(Name = "PosterURL")]
        public string PosterURL { get; set; }
    }
}
