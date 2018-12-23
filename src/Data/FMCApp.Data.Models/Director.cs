using System;
using System.Collections.Generic;
using System.Text;

namespace FMCApp.Data.Models
{
    //Not sure for that model
    public class Director
    {
        public Director()
        {
            this.Movies = new HashSet<Movie>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; } // Information about Director 
        public DateTime? Birthdate { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
    