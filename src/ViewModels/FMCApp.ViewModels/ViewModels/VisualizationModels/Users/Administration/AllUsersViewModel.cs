using System;
using System.Collections.Generic;
using System.Text;

namespace FMCApp.ViewModels.ViewModels.VisualizationModels.Users.Administration
{
    public class AllUsersViewModel
    {
        public AllUsersViewModel()
        {
            this.Users = new HashSet<UsersViewModel>();
        }
        public IEnumerable<UsersViewModel> Users { get; set; }
    }
}
