using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BlogClub.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() 
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "这是一个伟大的胜利.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "来草我们吧.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
