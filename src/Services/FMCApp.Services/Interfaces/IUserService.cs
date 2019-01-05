using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FMCApp.Web.Models.ViewModels.InputModels;
using FMCApp.Web.Models.ViewModels.VisualizationModels.Watchlist;
using Microsoft.AspNetCore.Identity;

namespace FMCApp.Services.Interfaces
{
    public interface IUserService
    {
        SignInResult LogUser(LoginInputModel model);
        Task<IdentityResult> RegisterUser(RegisterInputModel model);
        IQueryable<UserWatchlistViewModel> Watchlist();
        void RemoveFromWatchlist(int id);
    }
}
