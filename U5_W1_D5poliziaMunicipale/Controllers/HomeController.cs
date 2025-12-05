using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using U5_W1_D5poliziaMunicipale.Models;

namespace U5_W1_D5poliziaMunicipale.Controllers
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

    }
}
