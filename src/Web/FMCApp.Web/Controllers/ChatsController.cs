using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FMCApp.Web.Controllers
{
    [Authorize]
    public class ChatsController : Controller
    {
        public IActionResult OpenChat()
        {
            return View();
        }
    }
}