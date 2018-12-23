using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using FMCApp.Data.Models.Enums;

namespace FMCApp.Data.Models
{
    public class Movie
    {
        public Movie()
        {
            this.Comments = new HashSet<Comment>();
            this.WatchLists = new HashSet<WatchList>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public string Description { get; set; }
        //public string DirectorName { get; set; }
        //public DateTime? DirectorBirthDate { get; set; }
        public int DirectorId { get; set; }
        public Director Director { get; set; }
        public string MoviePosterUrl { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public ICollection<Comment> Comments{ get; set; }
        public ICollection<WatchList> WatchLists { get; set; }
    }
}
