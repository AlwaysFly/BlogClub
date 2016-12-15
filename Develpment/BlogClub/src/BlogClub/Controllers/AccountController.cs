using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Identity.Dapper.Entities;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogClub.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<DapperIdentityUser> _userManager;
        private readonly SignInManager<DapperIdentityUser> _signInManager;
        //private readonly IEmailSender _emailSender;
        //private readonly ISmsSender _smsSender;
        private readonly ILogger _logger;
        public AccountController(
        UserManager<DapperIdentityUser> userManager,
        SignInManager<DapperIdentityUser> signInManager,
        //IEmailSender emailSender,
        //ISmsSender smsSender,
        ILoggerFactory loggerFactory)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            //_emailSender = emailSender;
            //_smsSender = smsSender;
            _logger = loggerFactory.CreateLogger<AccountController>();
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
