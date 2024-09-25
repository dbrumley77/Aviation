using Aviation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Aviation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //Method controlls (loads) the webpage to view. Ref: Views->Home->Index.cshtml
        public IActionResult Index()
        {
            return View();
        }

        //Method controlls (loads) the webpage to view. Ref: Views->Home->Privacy.cshtml
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
