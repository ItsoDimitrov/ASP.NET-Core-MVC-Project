using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMCApp.Web.Models.ViewModels.VisualizationModels.News
{
    public class AllNewsesViewModel
    {
        public AllNewsesViewModel()
        {
            this.Newses = new HashSet<NewsViewModel>();
        }
        public IEnumerable<NewsViewModel> Newses { get; set; }
    }
}
