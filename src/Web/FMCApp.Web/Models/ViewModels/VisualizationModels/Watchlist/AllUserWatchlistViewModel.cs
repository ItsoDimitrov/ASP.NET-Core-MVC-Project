using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMCApp.Web.Models.ViewModels.VisualizationModels.Watchlist
{
    public class AllUserWatchlistViewModel
    {
        public AllUserWatchlistViewModel()
        {
            this.userWatchlist = new HashSet<UserWatchlistViewModel>();
        }
        public IEnumerable<UserWatchlistViewModel> userWatchlist { get; set; }

    }
}
