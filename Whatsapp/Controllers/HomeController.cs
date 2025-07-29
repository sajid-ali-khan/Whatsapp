using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Whatsapp.Models;

namespace Whatsapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Contacts()
        {
            return View();
        }

        public IActionResult NewContact()
        {
            return View();
        }

        public IActionResult Chat()
        {
            return View();
        }
    }
}
