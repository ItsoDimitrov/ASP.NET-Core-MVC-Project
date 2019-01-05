using System;
using System.Collections.Generic;
using System.Text;
using FMCApp.Data;
using FMCApp.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace FMCApp.Services
{
    public abstract class BaseService
    {
        protected FMCAppContext _context { get; }

        protected UserManager<FMCAppUser> _userManager { get; }
        protected BaseService(FMCAppContext context, UserManager<FMCAppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
       
    }
}
