using BxlForm.DemoSecurity.Areas.Admin.Infrastructure.Security;
using BxlForm.DemoSecurity.Models.Client.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BxlForm.DemoSecurity.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AdminRequired]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
