﻿using System;
using System.Collections.Generic;
using System.Text;
using FMCApp.Web.Models.ViewModels.InputModels;
using Microsoft.AspNetCore.Identity;

namespace FMCApp.Services.Interfaces
{
    public interface IUserService
    {
        SignInResult LogUser(LoginInputModel model);

    }
}
