using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMCApp.Web.Models.ViewModels.VisualizationModels.Watchlist
{
    public class UserWatchlistViewModel
    {
        public int Id { get; set; }
        public DateTime AddedOn { get; set; }
        public string MoviePosterUrl { get; set; }
        public string MovieTitle { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        

    }
}
